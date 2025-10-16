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
    public partial class ComisionDetalle : Form
    {
        private ComisionDTO comision;
        private FormMode mode;
        private List<PlanDTO> planes = new();

        public ComisionDTO Comision
        {
            get { return comision; }
            set
            {
                comision = value;
                this.SetComision();
            }
        }


        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public ComisionDetalle()
        {
            InitializeComponent();
        }

        private async void ComisionDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                planes = (await PlanApi.GetAllAsync()).ToList();

                comboBoxPlan.DataSource = planes;
                comboBoxPlan.DisplayMember = "DescPlan";
                comboBoxPlan.ValueMember = "IDPlan";
                comboBoxPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (this.Comision != null && this.Comision.IDPlan > 0)
            {
                comboBoxPlan.SelectedValue = this.Comision.IDPlan;
            }
        }

        private async void aceptarButton(object sender, EventArgs e)
        {
            if (!ValidateComision()) return;

            try
            {
                this.Comision ??= new ComisionDTO();
                this.Comision.Descripcion = textBox1.Text;
                this.Comision.AnioEspecialidad = int.Parse(textBoxAnio.Text);
                this.Comision.IDPlan = (int)comboBoxPlan.SelectedValue;

                if (this.Mode == FormMode.Update)
                {
                    if (this.Comision.IDComision <= 0)
                        throw new InvalidOperationException("ID de comisión inválido (<= 0).");

                    await ComisionApi.UpdateAsync(this.Comision);
                }
                else
                {
                    await ComisionApi.AddAsync(this.Comision);
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
                this.Text = "Agregar Comision";
                if (this.Comision == null)
                    this.Comision = new ComisionDTO();
                textBox1.Text = string.Empty;
            }
            else
            {
                this.Text = "Modificar Comisión";
                if (this.Comision != null)
                {
                    textBox1.Text = this.Comision.Descripcion;
                }
            }
        }

        private void SetComision()
        {
            if (this.Comision != null)
            {
                this.textBox1.Text = this.Comision.Descripcion;
                this.textBoxAnio.Text = this.Comision.AnioEspecialidad.ToString();
                comboBoxPlan.SelectedValue = this.Comision.IDPlan;
            }
        }

        private bool ValidateComision()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBoxAnio.Text, out int anio) || anio <= 0)
            {
                MessageBox.Show("El año de especialidad debe ser mayor que 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxPlan.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un plan.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void comboBoxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAnio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
