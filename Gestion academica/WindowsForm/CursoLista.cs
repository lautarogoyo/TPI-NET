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
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.cursosDataGridView.DataSource = null;
                IEnumerable<CursoDTO> cursos;
                cursos = await CursoApi.GetWithComisionMateria();
                cursosDataGridView.DataSource = cursos.ToList();
                if (this.cursosDataGridView.Rows.Count > 0)
                {
                    this.cursosDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                }
                this.agregarButton.Enabled = true;

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
            CursoDTO curso;
            curso = (CursoDTO)cursosDataGridView.SelectedRows[0].DataBoundItem;
            return curso;
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            CursoDetalle cursoDetalle = new CursoDetalle();

            CursoDTO cursoNuevo = new CursoDTO();

            cursoDetalle.Mode = FormMode.Add;
            cursoDetalle.Curso = cursoNuevo;

            if (cursoDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Curso agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.CargarCursos();
        }
        private void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CursoDetalle cursoDetalle = new CursoDetalle();
                CursoDTO curso = this.SelectedItem();            

                cursoDetalle.Mode = FormMode.Update;
                cursoDetalle.Curso = curso;

                if (cursoDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Curso actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.CargarCursos();
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
                CursoDTO curso = this.SelectedItem();

                var confirm = MessageBox.Show(
               "¿Desea eliminar este curso>?",
               "Confirmar eliminación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await CursoApi.DeleteAsync(curso.IdCurso);
                    MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CargarCursos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cursosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
