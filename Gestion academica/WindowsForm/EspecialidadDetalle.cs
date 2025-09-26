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

namespace WindowsForm
{ 
    public enum FormMode
    {
        Add,
        Update
    }
    public partial class EspecialidadDetalle : Form
    {

        private EspecialidadDTO especialidad;
        private FormMode mode;

        public EspecialidadDTO Especialidad
        {
            get { return especialidad; }
            set { especialidad = value;
                this.SetEspecialidad();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set {
                SetFormMode(value);
            }
        }
        public EspecialidadDetalle()
        {
            InitializeComponent();
        }

        private void EspecialidadDetalle_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void aceptarButton(object sender, EventArgs e)
        {
            if (!ValidateEspecialidad()) return;

            try
            {
                this.Especialidad ??= new EspecialidadDTO();
                this.Especialidad.Descripcion = textBox1.Text;

                if (this.Mode == FormMode.Update)
                {
                    if (this.Especialidad.IDEspecialidad <= 0)
                        throw new InvalidOperationException("ID de especialidad inválido (<= 0).");

                    // Tu backend: PUT /especialidades (sin {id})
                    await EspecialidadApi.UpdateAsync(this.Especialidad);
                }
                else
                {
                    await EspecialidadApi.AddAsync(this.Especialidad);
                }

                this.DialogResult = DialogResult.OK;   // ← importante para refrescar
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
                this.Text = "Agregar Especialidad";
                if (this.Especialidad == null)                // no pises un DTO existente
                    this.Especialidad = new EspecialidadDTO();
                textBox1.Text = string.Empty;
            }
            else // Update
            {
                this.Text = "Modificar Especialidad";
                if (this.Especialidad != null)
                    textBox1.Text = this.Especialidad.Descripcion;
            }
        }
        private void SetEspecialidad()
        {

            if (this.Especialidad != null)
                this.textBox1.Text = this.Especialidad.Descripcion;

        }
        private bool ValidateEspecialidad()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
