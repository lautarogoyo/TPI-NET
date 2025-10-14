using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForm
{
    public partial class ComisionMateriaDetalle : Form
    {
        private ComisionMateriaDTO comisionMateria;
        private FormMode mode;
        private List<MateriaDTO> materias = new();

        public ComisionMateriaDTO ComisionMateria
        {
            get { return comisionMateria; }
            set
            {
                comisionMateria = value;
                this.SetComisionMateria();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }
        public ComisionMateriaDetalle()
        {
            InitializeComponent();
        }

        private void SetComisionMateria()
        {
            if (this.comisionMateria != null)
            {
                this.textBoxHsSemanales.Text = this.comisionMateria.HsSemanales.ToString();
                this.textBoxHsTotales.Text = this.comisionMateria.HsTotales.ToString();
                this.comboBoxMateria.SelectedValue = this.comisionMateria.IDMateria;
            }
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (mode == FormMode.Add)
            {
                this.Text = "Agregar Materia";
                if (this.ComisionMateria == null)
                    this.ComisionMateria = new ComisionMateriaDTO();
                textBoxHsSemanales.Text = string.Empty;
                textBoxHsTotales.Text = string.Empty;
            }
            else
            {
                this.Text = "Modificar Horas";
                if (this.ComisionMateria != null)
                {
                    textBoxHsSemanales.Text = this.ComisionMateria.HsSemanales.ToString();
                    textBoxHsTotales.Text = this.ComisionMateria.HsTotales.ToString();
                    comboBoxMateria.Enabled = false;
                }
            }

        }
        private async void ComisionMateriaDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                materias = (await MateriaApi.GetAllAsync()).ToList();
                comboBoxMateria.DataSource = materias;
                comboBoxMateria.DisplayMember = "Descripcion";
                comboBoxMateria.ValueMember = "IDMateria";
            

                if (this.ComisionMateria != null && this.ComisionMateria.IDMateria > 0)
                {
                    comboBoxMateria.SelectedValue = this.ComisionMateria.IDMateria;
                }

                comboBoxMateria.Enabled = (this.Mode == FormMode.Add);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateComisionMateria()) return;

            try
            {
                this.ComisionMateria ??= new ComisionMateriaDTO();
                this.ComisionMateria.HsSemanales = int.Parse(textBoxHsSemanales.Text);
                this.ComisionMateria.HsTotales= int.Parse(textBoxHsTotales.Text);
                this.ComisionMateria.IDMateria = (int)comboBoxMateria.SelectedValue;

                var existing = (await ComisionMateriaApi.GetByComisionAsync(ComisionMateria.IDComision))    
                   .FirstOrDefault(cm => cm.IDMateria == (int)comboBoxMateria.SelectedValue);

                if (existing != null)
                {
                    MessageBox.Show("Esta materia ya está asignada a la comisión.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.Mode == FormMode.Update)
                {
                if (this.ComisionMateria.IDComisionMateria <= 0)
                    throw new InvalidOperationException("ID de comisiónmateria inválido (<= 0).");

                await ComisionMateriaApi.UpdateAsync(this.ComisionMateria);
                }
                else
                {
                    await ComisionMateriaApi.AddAsync(this.ComisionMateria);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateComisionMateria()
        {
            if (!int.TryParse(textBoxHsSemanales.Text, out int hsS) || hsS <= 0)
            {
                MessageBox.Show("Las horas semanales deben ser válidas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(textBoxHsTotales.Text, out int hsT) || hsT <= 0)
            {
                MessageBox.Show("Las horas totales deben ser válidas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (comboBoxMateria.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una materia.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void comboBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
