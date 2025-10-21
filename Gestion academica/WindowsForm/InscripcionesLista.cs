using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class InscripcionesLista : Form
    {
        private int idCurso;
        private List<InscripcionDTO> inscripciones = new();

        public InscripcionesLista(int idCurso)
        {
            InitializeComponent();
            this.idCurso = idCurso;
            ConfigurarColumnas();
        }

        private async void InscripcionesLista_Load(object sender, EventArgs e)
        {
            await CargarInscriptosAsync();
        }

        private void ConfigurarColumnas()
        {
            dgvInscriptos.AutoGenerateColumns = false;
            dgvInscriptos.Columns.Clear();

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Alumno",
                DataPropertyName = "NombreAlumno",
                Width = 200
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "EmailAlumno",
                Width = 200
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Legajo",
                DataPropertyName = "LegajoAlumno",
                Width = 100
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Condición",
                DataPropertyName = "Condicion",
                Width = 100
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nota Final",
                DataPropertyName = "NotaFinal",
                Width = 80
            });

            dgvInscriptos.CellFormatting += (s, e) =>
            {
                if (dgvInscriptos.Columns[e.ColumnIndex].DataPropertyName == "NotaFinal")
                {
                    if (e.Value != null)
                    {
                        e.Value = (int)e.Value == -1 ? "     -" : $"     {e.Value}";
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        private async Task CargarInscriptosAsync()
        {
            try
            {
                var inscripciones = await InscripcionApi.GetByCurso(idCurso);
                dgvInscriptos.DataSource = inscripciones;

                if (inscripciones.Count == 0)
                    MessageBox.Show("No hay alumnos inscriptos en este curso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inscriptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
