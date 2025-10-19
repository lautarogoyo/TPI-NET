using System;
using System.Collections.Generic;
using System.Linq;
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
            _ = GetByCriteriaAndLoad();
        }

       
        private async void buscarButton_Click(object sender, EventArgs e)
        {
            string texto = buscarTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                await GetByCriteriaAndLoad();
                return;
            }

            await GetByCriteriaAndLoad(texto);
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
                    await GetByCriteriaAndLoad();
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

                _ = GetByCriteriaAndLoad();
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

            _ = GetByCriteriaAndLoad();
        }

        private EspecialidadDTO SelectedItem()
        {
            return (EspecialidadDTO)especialidadesDataGridView.SelectedRows[0].DataBoundItem;
        }

        
        private async Task GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
                agregarButton.Enabled = false;
                especialidadesDataGridView.DataSource = null;

                IEnumerable<EspecialidadDTO> especialidades;

                
                var todas = await EspecialidadApi.GetAllAsync();

                
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    especialidades = todas
                        .Where(e => e.Descripcion != null &&
                                    e.Descripcion.Contains(texto, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    especialidades = todas;
                }

                especialidadesDataGridView.DataSource = especialidades.ToList();

                
                bool hayFilas = especialidadesDataGridView.Rows.Count > 0;
                eliminarButton.Enabled = hayFilas;
                modificarButton.Enabled = hayFilas;
                agregarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
            }
        }

        
        private async void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(buscarTextBox.Text))
                await GetByCriteriaAndLoad();
        }
    }
}
