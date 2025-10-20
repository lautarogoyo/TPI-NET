using System;
using System.Collections.Generic;
using System.Linq;
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
            descripcionColumn.Width = 400;
            materiasDataGridView.Columns.Add(descripcionColumn);
        }

        private void MateriaLista_Load(object sender, EventArgs e)
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
                    await GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                MateriaDetalle materiaDetalle = new MateriaDetalle();

                MateriaDTO materia = this.SelectedItem();

                materiaDetalle.Mode = FormMode.Update;
                materiaDetalle.Materia = materia;

                if (materiaDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Materia actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _ = GetByCriteriaAndLoad();
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
                MessageBox.Show("Materia agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _ = GetByCriteriaAndLoad();
        }

        private MateriaDTO SelectedItem()
        {
            return (MateriaDTO)materiasDataGridView.SelectedRows[0].DataBoundItem;
        }

       
        private async Task GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
                agregarButton.Enabled = false;
                materiasDataGridView.DataSource = null;

                IEnumerable<MateriaDTO> materias;

               
                var todas = await MateriaApi.GetAllAsync();

                
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    materias = todas
                        .Where(m => m.Descripcion != null &&
                                    m.Descripcion.Contains(texto, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    materias = todas;
                }

                materiasDataGridView.DataSource = materias.ToList();

                
                bool hayFilas = materiasDataGridView.Rows.Count > 0;
                eliminarButton.Enabled = hayFilas;
                modificarButton.Enabled = hayFilas;
                agregarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de materias: {ex.Message}",
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
