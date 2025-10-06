using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class UsuarioDetalle : Form
    {
        private UsuarioDTO usuario;
        private FormMode mode;
        private bool _personasCargadas = false;
        private int? _pendingIdPersona;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                SetUsuario();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public UsuarioDetalle()
        {
            InitializeComponent();
        }

        private async void UsuarioDetalle_Load(object sender, EventArgs e)
        {
            await CargarPersonas();
        }

        private async Task CargarPersonas()
        {
            try
            {
                var personas = (await PersonaApi.GetAllAsync()).ToList();

                PersonaComboBox.DataSource = personas;
                PersonaComboBox.DisplayMember = "Nombre";  // o "Apellido", o combinados
                PersonaComboBox.ValueMember = "IDPersona";
                PersonaComboBox.SelectedIndex = -1;

                _personasCargadas = true;

                if (_pendingIdPersona.HasValue)
                    PersonaComboBox.SelectedValue = _pendingIdPersona.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUsuario()) return;

            try
            {
                this.Usuario ??= new UsuarioDTO();

                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                Usuario.Clave = ClaveTextBox.Text;
                Usuario.Habilitado = ParseBool(HabilitadoTextBox.Text);
                Usuario.IDPersona = (int)PersonaComboBox.SelectedValue;

                if (this.Mode == FormMode.Update)
                    UsuarioApi.UpdateAsync(Usuario).Wait();
                else
                    UsuarioApi.AddAsync(Usuario).Wait();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (mode == FormMode.Add)
            {
                this.Text = "Agregar Usuario";
                Usuario ??= new UsuarioDTO();

                IdTextBox.Text = string.Empty;
                NombreUsuarioTextBox.Text = string.Empty;
                ClaveTextBox.Text = string.Empty;
                HabilitadoTextBox.Text = "true";
                PersonaComboBox.SelectedIndex = -1;
            }
            else
            {
                this.Text = "Modificar Usuario";
                SetUsuario();
            }
        }

        private void SetUsuario()
        {
            if (Usuario == null) return;

            IdTextBox.Text = Usuario.IDUsuario.ToString();
            NombreUsuarioTextBox.Text = Usuario.NombreUsuario;
            ClaveTextBox.Text = Usuario.Clave;
            HabilitadoTextBox.Text = Usuario.Habilitado.ToString();

            if (_personasCargadas)
                PersonaComboBox.SelectedValue = Usuario.IDPersona;
            else
                _pendingIdPersona = Usuario.IDPersona;
        }

        private bool ValidateUsuario()
        {
            if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ClaveTextBox.Text))
            {
                MessageBox.Show("La clave es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (PersonaComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una persona.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ParseBool(string text)
        {
            return text.Trim().ToLowerInvariant() switch
            {
                "1" or "true" or "sí" or "si" or "s" or "yes" or "y" => true,
                _ => false
            };
        }
    }
}
