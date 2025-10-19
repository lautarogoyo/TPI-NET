using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class PersonaLista : Form
    {
        private string tipo;
<<<<<<< Updated upstream
        private int numero; // 1 = Alumno, 2 = Profesor
=======
        private int numero; // 1 = Alumno, 2 = Profesor, 0 = Todos

>>>>>>> Stashed changes
        public PersonaLista(int numero, string tipo)
        {
            this.numero = numero;
            this.tipo = tipo;
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            personasDataGridView.AutoGenerateColumns = false;
            personasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            personasDataGridView.MultiSelect = false;

            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID Persona",
                DataPropertyName = "IdPersona",
                Width = 60
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 150
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                Width = 150
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 200
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo Doc",
                DataPropertyName = "TipoDoc",
                Width = 80
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nro Doc",
                DataPropertyName = "NroDoc",
                Width = 100
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 100
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha Nac.",
                DataPropertyName = "FechaNac",
                Width = 100
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Legajo",
                DataPropertyName = "Legajo",
                Width = 80
            });
            personasDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo Persona",
                DataPropertyName = "TipoPersona",
                Width = 100
            });

            personasDataGridView.CellFormatting += (s, e) =>
            {
                if (personasDataGridView.Columns[e.ColumnIndex].DataPropertyName == "TipoPersona")
                {
                    if (e.Value != null)
                    {
                        e.Value = (int)e.Value == 1 ? "Alumno" : "Profesor";
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        private void PersonaLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        // === BOTÓN BUSCAR ===
        private async void buscarButton_Click(object sender, EventArgs e)
        {
            string texto = buscarTextBox.Text.Trim();

            // Si el cuadro está vacío, recarga todo
            if (string.IsNullOrWhiteSpace(texto))
            {
                this.GetByCriteriaAndLoad();
                return;
            }

            // Filtra por texto
            await GetByCriteriaAndLoad(texto);
        }

        // === SELECCIONAR PERSONA ===
        private PersonaDTO SelectedItem()
        {
            return (PersonaDTO)personasDataGridView.SelectedRows[0].DataBoundItem;
        }

        // === CARGAR PERSONAS (con o sin criterio) ===
        private async Task GetByCriteriaAndLoad(string texto = "")

        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.personasDataGridView.DataSource = null;

                IEnumerable<PersonaDTO> personas;

                // Si no hay texto de búsqueda → trae todo
                if (string.IsNullOrWhiteSpace(texto))
                {
                    personas = numero switch
                    {
                        1 => await PersonaApi.GetAllAlumnosAsync(),
                        2 => await PersonaApi.GetAllProfesoresAsync(),
                        _ => await PersonaApi.GetAllAsync()
                    };
                }
                else
                {
                    // Filtrado por nombre o apellido (sin importar mayúsculas/minúsculas)
                    var todas = numero switch
                    {
                        1 => await PersonaApi.GetAllAlumnosAsync(),
                        2 => await PersonaApi.GetAllProfesoresAsync(),
                        _ => await PersonaApi.GetAllAsync()
                    };

                    // Divide el texto en partes (por si escriben nombre y apellido)
                    var partes = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    personas = todas.Where(p =>
                    {
                        string nombreCompleto = $"{p.Nombre} {p.Apellido}".ToLower();
                        // Coincide si todas las palabras ingresadas están presentes en el nombre completo
                        return partes.All(palabra => nombreCompleto.Contains(palabra.ToLower()));
                    }).ToList();

                }

                this.personasDataGridView.DataSource = personas.ToList();

                if (this.personasDataGridView.Rows.Count > 0)
                {
                    this.personasDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de {tipo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        // === AGREGAR ===
        private void agregarButton_Click(object sender, EventArgs e)
        {
            PersonaDetalle personaDetalle = new PersonaDetalle(numero, tipo);

            PersonaDTO personaNuevo = new PersonaDTO();

            personaDetalle.Mode = FormMode.Add;
            personaDetalle.Persona = personaNuevo;

            if (personaDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"{tipo} agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.GetByCriteriaAndLoad();
        }

        // === MODIFICAR ===
        private void modificarButton_click(object sender, EventArgs e)
        {
            try
            {
                PersonaDetalle personaDetalle = new PersonaDetalle(numero, tipo);
                PersonaDTO persona = this.SelectedItem();

                personaDetalle.Persona = persona;
                personaDetalle.Mode = FormMode.Update;

                if (personaDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"{tipo} actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.GetByCriteriaAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el {tipo} para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ELIMINAR ===
        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDTO persona = this.SelectedItem();

                var confirm = MessageBox.Show(
                   $"¿Desea eliminar este {tipo}?",
                   "Confirmar eliminación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    await PersonaApi.DeleteAsync(persona.IDPersona);
                    MessageBox.Show($"{tipo} eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.GetByCriteriaAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar {tipo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === BUSCAR MIENTRAS SE ESCRIBE (opcional) ===
        private async void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            string texto = buscarTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
                await Task.Run(() => GetByCriteriaAndLoad());
        }
    }
}

