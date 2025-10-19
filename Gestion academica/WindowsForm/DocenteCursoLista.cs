using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class DocenteCursoLista : Form
    {
        private List<DocenteCurso> docentesCursos = new();

        public DocenteCursoLista()
        {
            InitializeComponent();
            this.Load += DocenteCursoLista_Load;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvDocentesCursos.AutoGenerateColumns = false;
            dgvDocentesCursos.Columns.Clear();

            DataGridViewTextBoxColumn idCursoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCurso",
                HeaderText = "ID Curso",
                Width = 120
            };
            dgvDocentesCursos.Columns.Add(idCursoColumn);

            DataGridViewTextBoxColumn idDocenteColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDDocente",
                HeaderText = "ID Docente",
                Width = 120
            };
            dgvDocentesCursos.Columns.Add(idDocenteColumn);

            DataGridViewTextBoxColumn cargoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cargo",
                HeaderText = "Cargo",
                Width = 150
            };
            dgvDocentesCursos.Columns.Add(cargoColumn);
        }

        private async void DocenteCursoLista_Load(object? sender, EventArgs e)
        {
            await CargarDocentesCursosAsync();
        }

        private async Task CargarDocentesCursosAsync(string criterio = "")
        {
            try
            {
                docentesCursos = (await DocenteCursoApi.GetAllAsync()).ToList();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    docentesCursos = docentesCursos.Where(dc =>
                        dc.Cargo.ToString().Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                        dc.IDCurso.ToString().Contains(criterio) ||
                        dc.IDDocente.ToString().Contains(criterio)
                    ).ToList();
                }

                dgvDocentesCursos.DataSource = docentesCursos;
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los Docentes-Cursos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarBotones()
        {
            bool hayFilas = dgvDocentesCursos.Rows.Count > 0;
            btnEliminar.Enabled = hayFilas;
            btnModificar.Enabled = hayFilas;
        }

        private DocenteCurso SelectedItem()
        {
            return (DocenteCurso)dgvDocentesCursos.SelectedRows[0].DataBoundItem;
        }

        private async void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                DocenteCursoDetalle detalle = new DocenteCursoDetalle
                {
                    Mode = FormMode.Add,
                    DocenteCurso = new DocenteCurso()
                };

                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Docente-Curso agregado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarDocentesCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object? sender, EventArgs e)
        {
            try
            {
                var seleccionado = SelectedItem();

                DocenteCursoDetalle detalle = new DocenteCursoDetalle
                {
                    Mode = FormMode.Update,
                    DocenteCurso = seleccionado
                };

                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Docente-Curso modificado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarDocentesCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                var seleccionado = SelectedItem();

                var confirm = MessageBox.Show(
                    "¿Desea eliminar este registro?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await DocenteCursoApi.DeleteAsync(seleccionado.IDCurso, seleccionado.IDDocente);

                    MessageBox.Show("Registro eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarDocentesCursosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🔍 NUEVO: botón Buscar
        private async void btnBuscar_Click(object? sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();
            await CargarDocentesCursosAsync(criterio);
        }

        // (opcional) búsqueda dinámica mientras se escribe
        private async void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            // Si querés que solo busque al hacer clic en el botón, podés eliminar este evento
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                await CargarDocentesCursosAsync();
        }
    }
}
