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
    public partial class PlanLista : Form
    {
        public PlanLista()
        {
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            planesDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDPlan";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            planesDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descPlanColumn = new DataGridViewTextBoxColumn();
            descPlanColumn.DataPropertyName = "DescPlan";
            descPlanColumn.HeaderText = "Descripción";
            descPlanColumn.Width = 200;
            planesDataGridView.Columns.Add(descPlanColumn);
        }
        private void PlanLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void planesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PlanDTO plan = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar este plan?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await PlanApi.DeleteAsync(plan.IDPlan);
                    MessageBox.Show("Plan eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                PlanDetalle planDetalle = new PlanDetalle();

                PlanDTO plan = this.SelectedItem();

                planDetalle.Mode = FormMode.Update;
                planDetalle.Plan = plan;

                if (planDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Plan actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el plan para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            PlanDetalle planDetalle = new PlanDetalle();

            PlanDTO planNuevo = new PlanDTO();

            planDetalle.Mode = FormMode.Add;
            planDetalle.Plan = planNuevo;

            if (planDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Plan agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.GetByCriteriaAndLoad();
        }
        private PlanDTO SelectedItem()
        {
            PlanDTO plan;
            plan = (PlanDTO)planesDataGridView.SelectedRows[0].DataBoundItem;
            return plan;
        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.planesDataGridView.DataSource = null;
                IEnumerable<PlanDTO> planes;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    planes = await PlanApi.GetAllAsync();
                }
                else
                {
                    planes = await PlanApi.GetByCriteriaAsync(texto);
                }

                this.planesDataGridView.DataSource = planes;
                if (this.planesDataGridView.Rows.Count > 0)
                {
                    this.planesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
