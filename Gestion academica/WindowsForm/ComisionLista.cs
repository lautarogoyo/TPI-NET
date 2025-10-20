using System;
using System.Collections.Generic;
using System.Linq;
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

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDComision",
                HeaderText = "ID",
                Width = 50
            };
            comisionesDataGridView.Columns.Add(idColumn);

            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 200
            };
            comisionesDataGridView.Columns.Add(descripcionColumn);

            DataGridViewTextBoxColumn anioEspecialidadColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AnioEspecialidad",
                HeaderText = "Año Especialidad",
                Width = 150
            };
            comisionesDataGridView.Columns.Add(anioEspecialidadColumn);

            DataGridViewTextBoxColumn planColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescPlan",
                HeaderText = "Plan",
                Width = 200
            };
            comisionesDataGridView.Columns.Add(planColumn);
        }

        private void ComisionLista_Load(object sender, EventArgs e)
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

        private void comisionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var comision = this.SelectedItem();
                if (comision == null)
                {
                    MessageBox.Show("Debe seleccionar una comisión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    "¿Desea eliminar esta comisión?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await ComisionApi.DeleteAsync(comision.IDComision);
                    MessageBox.Show("Comisión eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                var comision = this.SelectedItem();
                if (comision == null)
                {
                    MessageBox.Show("Debe seleccionar una comisión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ComisionDetalle comisionDetalle = new ComisionDetalle();
                comisionDetalle.Mode = FormMode.Update;
                comisionDetalle.Comision = comision;

                if (comisionDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Comisión actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _ = GetByCriteriaAndLoad();
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

            _ = GetByCriteriaAndLoad();
        }

        private ComisionDTO? SelectedItem()
        {
            if (comisionesDataGridView.SelectedRows.Count == 0)
                return null;
            return (ComisionDTO)comisionesDataGridView.SelectedRows[0].DataBoundItem;
        }

        private async Task GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
                verMateriasButton.Enabled = false;
                agregarButton.Enabled = false;
                comisionesDataGridView.DataSource = null;

                IEnumerable<ComisionDTO> comisiones;
                var todas = await ComisionApi.GetAllAsync();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    comisiones = todas
                        .Where(c => c.Descripcion != null &&
                                    c.Descripcion.Contains(texto, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    comisiones = todas;
                }

                comisionesDataGridView.DataSource = comisiones.ToList();

                bool hayFilas = comisionesDataGridView.Rows.Count > 0;
                eliminarButton.Enabled = hayFilas;
                modificarButton.Enabled = hayFilas;
                verMateriasButton.Enabled = hayFilas;
                agregarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de comisiones: {ex.Message}",
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

        private void verMateriasButton_Click(object sender, EventArgs e)
        {
            var seleccionada = this.SelectedItem();
            if (seleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una comisión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCom = seleccionada.IDComision;
            ComisionMateriaLista cmLista = new ComisionMateriaLista(idCom);
            cmLista.ShowDialog();
        }
    }
}
