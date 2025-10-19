using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForm
{
    public partial class UsuarioLista : Form
    {
        private List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
        private UsuarioDTO usuario;
        public UsuarioLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void UsuarioLista_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.deshabilitarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.usuariosDataGridView.DataSource = null;
                IEnumerable<UsuarioDTO> usuarios;
                usuarios = await UsuarioApi.GetAllWithPersonas();
                usuariosDataGridView.DataSource = usuarios.ToList();
                if (this.usuariosDataGridView.Rows.Count > 0)
                {
                    this.usuariosDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.deshabilitarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.deshabilitarButton.Enabled = false;
                }
                this.agregarButton.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            usuariosDataGridView.AutoGenerateColumns = false;
            usuariosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usuariosDataGridView.MultiSelect = false;
            usuariosDataGridView.Columns.Clear();

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "IDUsuario",
                Width = 60
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Usuario",
                DataPropertyName = "NombreUsuario",
                Width = 150
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Habilitado",
                DataPropertyName = "Habilitado",
                Width = 80
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Persona",
                DataPropertyName = "NombreApellidoPersona",
                Width = 150
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo Persona",
                DataPropertyName = "TipoPersona",
                Width = 100
            });

            usuariosDataGridView.CellFormatting += (s, e) =>
            {
                if (usuariosDataGridView.Columns[e.ColumnIndex].DataPropertyName == "TipoPersona")
                {
                    if (e.Value != null)
                    {
                        e.Value = (int)e.Value == 1 ? "Alumno" : "Profesor";
                        e.FormattingApplied = true;
                    }
                }
            };

        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string filtro = buscarTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                usuariosDataGridView.DataSource = usuarios;
                return;
            }

            var filtrados = usuarios
                .Where(u => u.NombreUsuario.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                .ToList();

            usuariosDataGridView.DataSource = filtrados;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            PersonasSinUsuario personasSinUsuario = new PersonasSinUsuario();
            personasSinUsuario.ShowDialog();
            this.CargarUsuarios();
        }

        private async void deshabilitarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm;
                if (this.SelectedItem().Habilitado == true)
                {
                    confirm = MessageBox.Show(
                    "¿Desea deshabilitar este usuario>?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    confirm = MessageBox.Show(
                    "¿Desea habilitar este usuario>?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                }
                if (confirm == DialogResult.Yes)
                {
                    this.usuario ??= new UsuarioDTO();
                    this.usuario.IDUsuario = this.SelectedItem().IDUsuario;
                    this.usuario.NombreUsuario = this.SelectedItem().NombreUsuario;
                    this.usuario.Clave = this.SelectedItem().Clave;
                    this.usuario.IDPersona = this.SelectedItem().IDPersona;
                    this.usuario.Habilitado = !this.SelectedItem().Habilitado;
                    await UsuarioApi.UpdateAsync(this.usuario);
                    this.CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuario = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar este usuario>?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await UsuarioApi.DeleteAsync(usuario.IDUsuario);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vacío si no se usa
        }

        private UsuarioDTO SelectedItem()
        {
            UsuarioDTO usuario;
            usuario = (UsuarioDTO)usuariosDataGridView.SelectedRows[0].DataBoundItem;
            return usuario;
        }
    }
}
