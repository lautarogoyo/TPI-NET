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
                HeaderText = "ID Inscripción",
                DataPropertyName = "IDInscripcion",
                Width = 100
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "NombreAlumno",
                Width = 150
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Apellido",
                DataPropertyName = "ApellidoAlumno",
                Width = 150
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Condición",
                DataPropertyName = "Condicion",
                Width = 120
            });

            dgvInscriptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nota Final",
                DataPropertyName = "NotaFinal",
                Width = 100
            });
        }

        private async Task CargarInscriptosAsync()
        {
            try
            {
                var todas = await InscripcionApi.GetAllAsync();
                inscripciones = todas
                    .Where(i => i.IDCurso == idCurso)
                    .ToList();

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
