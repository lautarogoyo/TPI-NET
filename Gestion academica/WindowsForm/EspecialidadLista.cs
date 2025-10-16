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
    public partial class EspecialidadLista : Form
    {
        public EspecialidadLista()
        {
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            especialidadesDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDEspecialidad";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            especialidadesDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
            descripcionColumn.DataPropertyName = "Descripcion";
            descripcionColumn.HeaderText = "Descripción";
            descripcionColumn.Width = 200;
            especialidadesDataGridView.Columns.Add(descripcionColumn);
        }
        private void EspecialidadLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void especialidadesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDTO especialidad = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar esta especialidad?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await EspecialidadApi.DeleteAsync(especialidad.IDEspecialidad);
                    MessageBox.Show("Especialidad eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle();

                EspecialidadDTO especialidad = this.SelectedItem();

                especialidadDetalle.Mode = FormMode.Update;
                especialidadDetalle.Especialidad = especialidad;

                if (especialidadDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Especialidad actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la especialidad para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle();

            EspecialidadDTO especialidadNuevo = new EspecialidadDTO();

            especialidadDetalle.Mode = FormMode.Add;
            especialidadDetalle.Especialidad = especialidadNuevo;

            if (especialidadDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Especialidad agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.GetByCriteriaAndLoad();
        }
        private EspecialidadDTO SelectedItem()
        {
            EspecialidadDTO especialidad;
            especialidad = (EspecialidadDTO)especialidadesDataGridView.SelectedRows[0].DataBoundItem;
            return especialidad;
        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.especialidadesDataGridView.DataSource = null;
                IEnumerable<EspecialidadDTO> especialidades;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    especialidades = await EspecialidadApi.GetAllAsync();
                }
                else
                {
                    especialidades = await EspecialidadApi.GetByCriteriaAsync(texto);
                }

                this.especialidadesDataGridView.DataSource = especialidades;
                if (this.especialidadesDataGridView.Rows.Count > 0)
                {
                    this.especialidadesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
