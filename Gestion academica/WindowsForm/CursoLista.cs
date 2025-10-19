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
        private List<CursoDTO> cursos = new();

        public CursoLista()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void CursoLista_Load(object sender, EventArgs e)
        {
            await CargarCursos();
        }

        
        private async Task CargarCursos(string filtro = "")
        {
            try
            {
                eliminarButton.Enabled = false;
                modificarButton.Enabled = false;
                agregarButton.Enabled = false;
                cursosDataGridView.DataSource = null;

                
                var todos = await CursoApi.GetWithComisionMateria();

                
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    cursos = todos
                        .Where(c => (c.Descripcion ?? "")
                            .Contains(filtro, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    cursos = todos.ToList();
                }

                cursosDataGridView.DataSource = cursos;

                if (cursosDataGridView.Rows.Count > 0)
                {
                    cursosDataGridView.Rows[0].Selected = true;
                    eliminarButton.Enabled = true;
                    modificarButton.Enabled = true;
                }
                else
                {
                    eliminarButton.Enabled = false;
                    modificarButton.Enabled = false;
                }

                agregarButton.Enabled = true;
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

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Curso",
                DataPropertyName = "IdCurso",
                Width = 60
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Curso",
                DataPropertyName = "Descripcion",
                Width = 200
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Comision",
                DataPropertyName = "DescComision",
                Width = 80
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Materia",
                DataPropertyName = "Descmateria",
                Width = 200
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Año",
                DataPropertyName = "AnioCalendario",
                Width = 100
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cupo",
                DataPropertyName = "Cupo",
                Width = 80
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hs Semanales",
                DataPropertyName = "HsSemanales",
                Width = 100
            });

            cursosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hs Totales",
                DataPropertyName = "HsTotales",
                Width = 100
            });
        }

        private CursoDTO SelectedItem()
        {
            return (CursoDTO)cursosDataGridView.SelectedRows[0].DataBoundItem;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            CursoDetalle cursoDetalle = new CursoDetalle
            {
                Mode = FormMode.Add,
                Curso = new CursoDTO()
            };

            if (cursoDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Curso agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            await CargarCursos();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CursoDetalle cursoDetalle = new CursoDetalle
                {
                    Mode = FormMode.Update,
                    Curso = SelectedItem()
                };

                if (cursoDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Curso actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await CargarCursos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el curso para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CursoDTO curso = SelectedItem();

                var confirm = MessageBox.Show(
                    "¿Desea eliminar este curso?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await CursoApi.DeleteAsync(curso.IdCurso);
                    MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarCursos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cursosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
        private async void buscarButton_Click(object sender, EventArgs e)
        {
            string filtro = (buscarTextBox.Text ?? "").Trim();
            await CargarCursos(filtro);
        }

        
        private async void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(buscarTextBox.Text))
                await CargarCursos();
        }
    }
}
