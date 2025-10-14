using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class PlanDetalle : Form
    {
        private PlanDTO plan;
        private FormMode mode;
        private List<EspecialidadDTO> especialidades = new();

        public PlanDTO Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                this.SetPlan();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public PlanDetalle()
        {
            InitializeComponent();
        }

        private async void PlanDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                especialidades = (await EspecialidadApi.GetAllAsync()).ToList();

                comboBoxEspecialidad.DataSource = especialidades;
                comboBoxEspecialidad.DisplayMember = "Descripcion"; 
                comboBoxEspecialidad.ValueMember = "IDEspecialidad"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (this.Plan != null && this.Plan.IDEspecialidad > 0)
            {
                comboBoxEspecialidad.SelectedValue = this.Plan.IDEspecialidad;
            }
        }

        private async void aceptarButton(object sender, EventArgs e)
        {
            if (!ValidatePlan()) return;

            try
            {
                this.Plan ??= new PlanDTO();
                this.Plan.DescPlan = textBox1.Text;
                this.Plan.IDEspecialidad = (int)comboBoxEspecialidad.SelectedValue; 

                if (this.Mode == FormMode.Update)
                {
                    if (this.Plan.IDPlan <= 0)
                        throw new InvalidOperationException("ID de plan inválido (<= 0).");

                    await PlanApi.UpdateAsync(this.Plan);
                }
                else
                {
                    await PlanApi.AddAsync(this.Plan);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                this.Text = "Agregar Plan";
                if (this.Plan == null)
                    this.Plan = new PlanDTO();
                textBox1.Text = string.Empty;
            }
            else
            {
                this.Text = "Modificar Plan";
                if (this.Plan != null)
                {
                    textBox1.Text = this.Plan.DescPlan;
                }
            }
        }

        private void SetPlan()
        {
            if (this.Plan != null)
            {
                this.textBox1.Text = this.Plan.DescPlan;
                comboBoxEspecialidad.SelectedValue = this.Plan.IDEspecialidad;
            }
        }

        private bool ValidatePlan()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
