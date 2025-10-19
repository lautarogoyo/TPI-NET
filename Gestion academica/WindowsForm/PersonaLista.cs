using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class PersonaLista : Form
    {
        private string tipo;
        private int numero; // 1 = Alumno, 2 = Profesor
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

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void personasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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

        private async void modificarButton_click(object sender, EventArgs e)
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
        private PersonaDTO SelectedItem()
        {
            PersonaDTO persona;
            persona = (PersonaDTO)personasDataGridView.SelectedRows[0].DataBoundItem;
            return persona;
        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
                this.agregarButton.Enabled = false;
                this.personasDataGridView.DataSource = null;
                IEnumerable<PersonaDTO> personas;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    if (numero == 1)
                    {
                        personas = await PersonaApi.GetAllAlumnosAsync();
                    }
                    else if (numero == 2)
                    {
                        personas = await PersonaApi.GetAllProfesoresAsync();
                    }
                    else
                    {
                        personas = await PersonaApi.GetAllAsync();
                    }
                }
                else
                {
                    personas = null; //await PersonaApi.GetByCriteriaAsync(texto);
                }

                this.personasDataGridView.DataSource = personas;
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
    }
}
