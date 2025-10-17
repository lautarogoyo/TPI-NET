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
    public partial class PersonaDetalle : Form
    {
        private PersonaDTO persona;
        private FormMode mode;
        private int numero;
        private string tipo;
        public PersonaDTO Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                SetPersona();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public PersonaDetalle(int numero, string tipo)
        {
            InitializeComponent();
            this.numero = numero;
            this.tipo = tipo;
        }

        private async void PersonaDetalle_Load(object sender, EventArgs e)
        {

            LoadCombox();
            if (Mode == FormMode.Update)
            {
                if (Persona != null)
                    SetPersona();

            }
        }
        private void LoadCombox()
        {
            tipoPersonaComboBox.DataSource = new[]
            {
                new { Text = "Alumno", Value = 1 },
                new { Text = "Profesor", Value = 2 }
            };
            tipoPersonaComboBox.DisplayMember = "Text";
            tipoPersonaComboBox.ValueMember = "Value";
            tipoPersonaComboBox.SelectedIndex = -1;
            tipoPersonaComboBox.Enabled = false;
            tipoPersonaComboBox.SelectedValue = this.numero;

            tipoDocComboBox.DataSource = new[]
            {
                new { Text = "DNI", Value = "DNI" },
                new { Text = "Libreta cívica", Value = "LC" },
                new {Text = "Libreta de enrolamiento", Value = "LE" }
            };
            tipoDocComboBox.DisplayMember = "Text";
            tipoDocComboBox.ValueMember = "Value";
            tipoDocComboBox.SelectedIndex = -1;
        }
        
        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePersona()) return;

            try
            {
                this.Persona ??= new PersonaDTO();
                this.Persona.Nombre = nombreTextBox.Text;
                this.Persona.Apellido = apellidoTextBox.Text;
                this.Persona.Email = emailTextBox.Text;
                this.Persona.Direccion = direccionTextBox.Text;
                this.Persona.Telefono = telefonoTextBox.Text;
                this.Persona.Legajo = legajoTextBox.Text;
                this.Persona.TipoDoc = (string)tipoDocComboBox.SelectedValue;
                this.Persona.NroDoc = nroDocTextBox.Text;
                this.Persona.FechaNac = DateOnly.FromDateTime(fechaNacPicker.Value);
                this.Persona.TipoPersona = (int)tipoPersonaComboBox.SelectedValue;

                if (this.Mode == FormMode.Update)
                {
                    if (this.Persona.IDPersona <= 0)
                        throw new InvalidOperationException("ID de persona inválido (<= 0).");

                    await PersonaApi.UpdateAsync(this.Persona);
                }
                else
                {
                    await PersonaApi.AddAsync(this.Persona);
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

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                this.Text = $"Agregar {tipo}";
                if (this.Persona == null)
                    this.Persona = new PersonaDTO();
                nombreTextBox.Text = string.Empty;
                apellidoTextBox.Text = string.Empty;
                emailTextBox.Text = string.Empty;
                direccionTextBox.Text = string.Empty;
                telefonoTextBox.Text = string.Empty;
                legajoTextBox.Text = string.Empty;
                tipoDocComboBox.SelectedIndex = -1;
                nroDocTextBox.Text = string.Empty;
                fechaNacPicker.Value = DateTime.Today;
            }
            else
            {
                this.Text = $"Modificar {tipo}";
                SetPersona();
            }
        }

        private void SetPersona()
        {
            if (this.Persona != null)
            {
                this.nombreTextBox.Text = this.Persona.Nombre;
                this.apellidoTextBox.Text = this.Persona.Apellido;
                this.emailTextBox.Text = this.Persona.Email;
                this.direccionTextBox.Text = this.Persona.Direccion;
                this.telefonoTextBox.Text = this.Persona.Telefono;
                this.legajoTextBox.Text = this.Persona.Legajo;
                this.tipoDocComboBox.SelectedValue = this.Persona.TipoDoc;
                this.nroDocTextBox.Text = this.Persona.NroDoc;
                if (Mode==FormMode.Add)
                    this.fechaNacPicker.Value = DateTime.Today;
                else fechaNacPicker.Value = this.Persona.FechaNac.ToDateTime(TimeOnly.MinValue);
            }
        }

        private bool ValidatePersona()
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellidoTextBox.Text))
            {
                MessageBox.Show("El apellido no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("El email no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(direccionTextBox.Text))
            {
                MessageBox.Show("La dirección no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                MessageBox.Show("El teléfono no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(legajoTextBox.Text))
            {
                MessageBox.Show("El legajo no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tipoDocComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nroDocTextBox.Text))
            {
                MessageBox.Show("El número de documento no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tipoPersonaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de persona (Alumno o Profesor).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (fechaNacPicker.Value == DateTime.MinValue)
            {
                MessageBox.Show("Debe seleccionar una fecha de nacimiento válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
