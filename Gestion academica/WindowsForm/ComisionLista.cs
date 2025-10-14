using System;
using System.Collections.Generic;
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
    public partial class ComisionLista : Form
    {
        public ComisionLista()
        {
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            comisionesDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDComision";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            comisionesDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
            descripcionColumn.DataPropertyName = "Descripcion";
            descripcionColumn.HeaderText = "Descripción";
            descripcionColumn.Width = 200;
            comisionesDataGridView.Columns.Add(descripcionColumn);
            DataGridViewTextBoxColumn anioEspecialidadColumn = new DataGridViewTextBoxColumn();
            anioEspecialidadColumn.DataPropertyName = "AnioEspecialidad";
            anioEspecialidadColumn.HeaderText = "Año especialidad";
            anioEspecialidadColumn.Width = 200;
            comisionesDataGridView.Columns.Add(anioEspecialidadColumn);
        }
        private void ComisionLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void comisionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionDTO comision = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar esta comisión>?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await ComisionApi.DeleteAsync(comision.IDComision);
                    MessageBox.Show("Comisión eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                ComisionDetalle comisionDetalle = new ComisionDetalle();

                int id = this.SelectedItem().IDComision;

                ComisionDTO comision = await ComisionApi.GetAsync(id);

                comisionDetalle.Mode = FormMode.Update;
                comisionDetalle.Comision = comision;

                if (comisionDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Comisión actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la comisión para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            ComisionDetalle comisionDetalle = new ComisionDetalle();

            ComisionDTO comisionNuevo = new ComisionDTO();

            comisionDetalle.Mode = FormMode.Add;
            comisionDetalle.Comision = comisionNuevo;

            if (comisionDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Comisión agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.GetByCriteriaAndLoad();
        }
        private ComisionDTO SelectedItem()
        {
            ComisionDTO comision;
            comision = (ComisionDTO)comisionesDataGridView.SelectedRows[0].DataBoundItem;
            return comision;
        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.verMateriasButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.comisionesDataGridView.DataSource = null;
                IEnumerable<ComisionDTO> comisiones;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    comisiones = await ComisionApi.GetAllAsync();
                }
                else
                {
                    comisiones = await ComisionApi.GetByCriteriaAsync(texto);
                }

                this.comisionesDataGridView.DataSource = comisiones;
                if (this.comisionesDataGridView.Rows.Count > 0)
                {
                    this.comisionesDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                    this.verMateriasButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                    this.verMateriasButton.Enabled = false;
                }
                this.agregarButton.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void verMateriasButton_Click(object sender, EventArgs e)
        {
            int idCom = this.SelectedItem().IDComision;
            ComisionMateriaLista cmLista = new ComisionMateriaLista(idCom);
            cmLista.ShowDialog();

        }
    }
}
