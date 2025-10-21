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
        private List<DocenteCursoDTO> docentesCursos = new();

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

            
            DataGridViewTextBoxColumn idDocenteCursoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdDocenteCurso",
                HeaderText = "ID Asignación",
                Width = 100
            };
            dgvDocentesCursos.Columns.Add(idDocenteCursoColumn);

            
            DataGridViewTextBoxColumn cursoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DescCurso",
                HeaderText = "Curso",
                Width = 300
            };
            dgvDocentesCursos.Columns.Add(cursoColumn);

            
            DataGridViewTextBoxColumn docenteColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreDocente",
                HeaderText = "Docente",
                Width = 200
            };
            dgvDocentesCursos.Columns.Add(docenteColumn);

            
            DataGridViewTextBoxColumn cargoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cargo",
                HeaderText = "Cargo",
                Width = 100
            };
            dgvDocentesCursos.Columns.Add(cargoColumn);

            
            DataGridViewTextBoxColumn idCursoColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDCurso",
                HeaderText = "ID Curso",
                Width = 80
            };
            dgvDocentesCursos.Columns.Add(idCursoColumn);

            
            DataGridViewTextBoxColumn idDocenteColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IDDocente",
                HeaderText = "ID Docente",
                Width = 80
            };
            dgvDocentesCursos.Columns.Add(idDocenteColumn);
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
            if (hayFilas)
                this.dgvDocentesCursos.Rows[0].Selected = hayFilas;
            btnEliminar.Enabled = hayFilas;
            btnModificar.Enabled = hayFilas;
        }

        private DocenteCursoDTO SelectedItem()
        {
            return (DocenteCursoDTO)dgvDocentesCursos.SelectedRows[0].DataBoundItem;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                DocenteCursoDetalle docenteCursoDetalle = new DocenteCursoDetalle();

                
                DocenteCursoDTO nuevoDocenteCurso = new DocenteCursoDTO();

                
                docenteCursoDetalle.Mode = FormMode.Add;
                docenteCursoDetalle.DocenteCurso = nuevoDocenteCurso;

                
                if (docenteCursoDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Asignación de docente a curso agregada exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la asignación: {ex.Message}",
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
                    await DocenteCursoApi.DeleteAsync(seleccionado.IdDocenteCurso);

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



        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                // Deshabilitamos los botones mientras se carga
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAgregar.Enabled = false;

                dgvDocentesCursos.DataSource = null;

                IEnumerable<DocenteCursoDTO> docentesCursos;

                // Si el texto está vacío, traemos todos
                if (string.IsNullOrWhiteSpace(texto))
                {
                    docentesCursos = await DocenteCursoApi.GetAllAsync();
                }
                else
                {
                    docentesCursos = await DocenteCursoApi.GetByCriteriaAsync(texto);
                }

                dgvDocentesCursos.DataSource = docentesCursos;

                // Habilitamos o deshabilitamos botones según si hay registros
                bool hayFilas = dgvDocentesCursos.Rows.Count > 0;
                if (hayFilas) this.dgvDocentesCursos.Rows[0].Selected = true;
                btnEliminar.Enabled = hayFilas;
                btnModificar.Enabled = hayFilas;
                btnAgregar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de docentes por curso: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }



    }
}
