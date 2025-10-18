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
    public partial class PersonasSinUsuario : Form
    {
        public PersonasSinUsuario()
        {
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
        private void PersonasSinUsuario_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void personasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            UsuarioDetalle usuarioDetalle = new UsuarioDetalle(SelectedItem().IDPersona);

            UsuarioDTO usuarioNuevo = new UsuarioDTO();

            usuarioDetalle.Mode = FormMode.Add;
            usuarioDetalle.Usuario = usuarioNuevo;

            if (usuarioDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Usuario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.agregarButton.Enabled = false;
                this.personasDataGridView.DataSource = null;
                IEnumerable<PersonaDTO> personas;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    personas = await PersonaApi.GetPersonasSinUsuario();
                }
                else
                {
                    personas = null; //await PersonaApi.GetByCriteriaAsync(texto);
                }

                this.personasDataGridView.DataSource = personas;
                if (this.personasDataGridView.Rows.Count > 0)
                {
                    this.personasDataGridView.Rows[0].Selected = true;
                }
                this.agregarButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
