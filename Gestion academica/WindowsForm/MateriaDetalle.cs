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
    public partial class MateriaDetalle : Form
    {

        private MateriaDTO materia;
        private FormMode mode;

        public MateriaDTO Materia
        {
            get { return materia; }
            set
            {
                materia = value;
                this.SetMateria();
            }
        }
        public FormMode Mode
        {
            get { return mode; }
            set
            {
                SetFormMode(value);
            }
        }
        public MateriaDetalle()
        {
            InitializeComponent();
        }

        private void MateriaDetalle_Load(object sender, EventArgs e)
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
            if (!ValidateMateria()) return;

            try
            {
                this.Materia ??= new MateriaDTO();
                this.Materia.Descripcion = textBox1.Text;

                if (this.Mode == FormMode.Update)
                {
                    if (this.Materia.IDMateria <= 0)
                        throw new InvalidOperationException("ID de materia inválido (<= 0).");

                    // Tu backend: PUT /materias (sin {id})
                    await MateriaApi.UpdateAsync(this.Materia);
                }
                else
                {
                    await MateriaApi.AddAsync(this.Materia);
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
                this.Text = "Agregar Materia";
                if (this.Materia == null)                // no pises un DTO existente
                    this.Materia = new MateriaDTO();
                textBox1.Text = string.Empty;
            }
            else // Update
            {
                this.Text = "Modificar Materia";
                if (this.Materia != null)
                    textBox1.Text = this.Materia.Descripcion;
            }
        }
        private void SetMateria()
        {

            if (this.Materia != null)
                this.textBox1.Text = this.Materia.Descripcion;

        }
        private bool ValidateMateria()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
