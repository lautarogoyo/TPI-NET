using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class MateriaLista : Form
    {
        public MateriaLista()
        {
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            materiasDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDMateria";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            materiasDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
            descripcionColumn.DataPropertyName = "Descripcion";
            descripcionColumn.HeaderText = "Nombre";
            descripcionColumn.Width = 200;
            materiasDataGridView.Columns.Add(descripcionColumn);
        }
        private void MateriaLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void materiasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaDTO materia = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar esta materia?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await MateriaApi.DeleteAsync(materia.IDMateria);
                    MessageBox.Show("Materia eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void modificarButton_click(object sender, EventArgs e)
        {
            try
            {MateriaDetalle materiaDetalle = new MateriaDetalle();

                int id = this.SelectedItem().IDMateria;
                MateriaDTO materia = await MateriaApi.GetAsync(id);

                materiaDetalle.Mode = FormMode.Update;
                materiaDetalle.Materia = materia;

                if (materiaDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Materia actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la materia para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            MateriaDetalle materiaDetalle = new MateriaDetalle();

            MateriaDTO materiaNuevo = new MateriaDTO();

            materiaDetalle.Mode = FormMode.Add;
            materiaDetalle.Materia = materiaNuevo;

            if (materiaDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("materia agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.GetByCriteriaAndLoad();
        }
        private MateriaDTO SelectedItem()
        {
            MateriaDTO materia;
            materia = (MateriaDTO)materiasDataGridView.SelectedRows[0].DataBoundItem;
            return materia;
        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.materiasDataGridView.DataSource = null;
                IEnumerable<MateriaDTO> materias;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    materias = await MateriaApi.GetAllAsync();
                }
                else
                {
                    materias = await MateriaApi.GetByCriteriaAsync(texto);
                }

                this.materiasDataGridView.DataSource = materias;
                if (this.materiasDataGridView.Rows.Count > 0)
                {
                    this.materiasDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                }
                this.agregarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }
    }
}
