using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class CursoLista : Form
    {
        private List<CursoDTO> cursos = new List<CursoDTO>();

        public CursoLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void CursoLista_Load(object sender, EventArgs e)
        {
            await CargarCursos();
        }

        private async Task CargarCursos()
        {
            try
            {
                cursos = (await CursoApi.GetAllAsync())?.ToList() ?? new List<CursoDTO>();
                cursosDataGridView.DataSource = cursos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            cursosDataGridView.AutoGenerateColumns = false;
            cursosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cursosDataGridView.MultiSelect = false;
            cursosDataGridView.Columns.Clear();

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "IdCurso",
                Width = 60
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                Width = 200
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Año",
                DataPropertyName = "AnioCalendario",
                Width = 80
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cupo",
                DataPropertyName = "Cupo",
                Width = 80
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Comisión",
                DataPropertyName = "IDComision",
                Width = 100
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Materia",
                DataPropertyName = "IDMateria",
                Width = 100
            });
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string filtro = (buscarTextBox.Text ?? "").Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                cursosDataGridView.DataSource = cursos;
                return;
            }

            var filtrados = cursos
                .Where(c => (c.Descripcion ?? "")
                    .Contains(filtro, StringComparison.OrdinalIgnoreCase))
                .ToList();

            cursosDataGridView.DataSource = filtrados;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            var form = new CursoDetalle { Mode = FormMode.Add };

            if (form.ShowDialog() == DialogResult.OK)
                await CargarCursos();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (cursosDataGridView.CurrentRow?.DataBoundItem is not CursoDTO curso) return;

            var form = new CursoDetalle
            {
                Mode = FormMode.Update,
                Curso = curso
            };

            if (form.ShowDialog() == DialogResult.OK)
                await CargarCursos();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (cursosDataGridView.CurrentRow?.DataBoundItem is not CursoDTO curso) return;

            var confirm = MessageBox.Show(
                "¿Desea eliminar este curso?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                await CursoApi.DeleteAsync(curso.IdCurso);
                await CargarCursos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar curso: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cursosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
