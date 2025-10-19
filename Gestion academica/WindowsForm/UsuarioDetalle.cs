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
        private int _idPersona;
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

        public UsuarioDetalle(int idPersona)
        {
            InitializeComponent();
            _idPersona = idPersona;
        }

        private async void UsuarioDetalle_Load(object sender, EventArgs e)
        {

        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateUsuario()) return;

            try
            {
                this.Usuario ??= new UsuarioDTO();
                Usuario.IDPersona = _idPersona;
                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                Usuario.Clave = ClaveTextBox.Text;
                Usuario.Habilitado = true;

                if (this.Mode == FormMode.Add)
                    await UsuarioApi.AddAsync(Usuario);

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

                NombreUsuarioTextBox.Text = string.Empty;
                ClaveTextBox.Text = string.Empty;
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

            NombreUsuarioTextBox.Text = Usuario.NombreUsuario;
            ClaveTextBox.Text = Usuario.Clave;
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

            return true;
        }
    }
}
