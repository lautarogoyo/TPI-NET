using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class UsuarioLista : Form
    {
        private List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

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
                usuarios = (await UsuarioApi.GetAllAsync()).ToList();
                usuariosDataGridView.DataSource = usuarios;
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
                HeaderText = "Clave",
                DataPropertyName = "Clave",
                Width = 100
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Habilitado",
                DataPropertyName = "Habilitado",
                Width = 80
            });

            usuariosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Persona",
                DataPropertyName = "IDPersona",
                Width = 80
            });
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
            var form = new UsuarioDetalle { Mode = FormMode.Add };
            if (form.ShowDialog() == DialogResult.OK)
                await CargarUsuarios();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (usuariosDataGridView.CurrentRow?.DataBoundItem is not UsuarioDTO usuario) return;

            var form = new UsuarioDetalle
            {
                Mode = FormMode.Update,
                Usuario = usuario
            };

            if (form.ShowDialog() == DialogResult.OK)
                await CargarUsuarios();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (usuariosDataGridView.CurrentRow?.DataBoundItem is not UsuarioDTO usuario) return;

            var confirm = MessageBox.Show(
                "¿Desea eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                await UsuarioApi.DeleteAsync(usuario.IDUsuario);
                await CargarUsuarios();
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
    }
}
