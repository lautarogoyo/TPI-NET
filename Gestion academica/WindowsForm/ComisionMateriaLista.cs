using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class ComisionMateriaLista : Form
    {
        private int _idCom;
        public ComisionMateriaLista(int idCom)
        {
            InitializeComponent();
            _idCom = idCom;
            configurarColumnas();
            
        }

        private void configurarColumnas()
        {
            cmDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDMateria";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            cmDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
            descripcionColumn.DataPropertyName = "DescMateria";
            descripcionColumn.HeaderText = "Materia";
            descripcionColumn.Width = 200;
            cmDataGridView.Columns.Add(descripcionColumn);
            DataGridViewTextBoxColumn hsSemanalesColumn = new DataGridViewTextBoxColumn();
            hsSemanalesColumn.DataPropertyName = "HsSemanales";
            hsSemanalesColumn.HeaderText = "Horas semanales";
            hsSemanalesColumn.Width = 150;
            cmDataGridView.Columns.Add(hsSemanalesColumn);
            DataGridViewTextBoxColumn hsTotalesColumn = new DataGridViewTextBoxColumn();
            hsTotalesColumn.DataPropertyName = "HsTotales";
            hsTotalesColumn.HeaderText = "Horas totales";
            hsTotalesColumn.Width = 150;
            cmDataGridView.Columns.Add(hsTotalesColumn);
        }
        private void ComisionVerMaterias_Load(object sender, EventArgs e)
        {
            this.GetLoad();
        }

        private async void GetLoad()
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.cmDataGridView.DataSource = null;
                IEnumerable<ComisionMateriaDTO> comisionesMaterias;
                comisionesMaterias = await ComisionMateriaApi.GetByComisionAsync(_idCom);
                cmDataGridView.DataSource = comisionesMaterias.ToList();
                if (this.cmDataGridView.Rows.Count > 0)
                {
                    this.cmDataGridView.Rows[0].Selected = true;
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
            }
        }


        private void cmDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void agregarButton_Click(object sender, EventArgs e)
        {
            ComisionMateriaDetalle comisionMateriaDetalle = new ComisionMateriaDetalle();

            ComisionMateriaDTO comisionMateriaNuevo = new ComisionMateriaDTO();
            comisionMateriaNuevo.IDComision = _idCom;

            comisionMateriaDetalle.Mode = FormMode.Add;
            comisionMateriaDetalle.ComisionMateria = comisionMateriaNuevo;

            if (comisionMateriaDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Materia agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.GetLoad();
        }
        private ComisionMateriaDTO SelectedItem()
        {
            ComisionMateriaDTO comisionMateria;
            comisionMateria = (ComisionMateriaDTO)cmDataGridView.SelectedRows[0].DataBoundItem;
            return comisionMateria;
        }
        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionMateriaDTO comisionMateria = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar esta quitar esta materia de la comisión seleccionada?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await ComisionMateriaApi.DeleteAsync(comisionMateria.IDComisionMateria);
                    MessageBox.Show("Materia quitada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionMateriaDetalle comisionMateriaDetalle = new ComisionMateriaDetalle();

                ComisionMateriaDTO comisionMateria = this.SelectedItem();

                comisionMateriaDetalle.Mode = FormMode.Update;
                comisionMateriaDetalle.ComisionMateria = comisionMateria;

                if (comisionMateriaDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Materia actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la materia para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
