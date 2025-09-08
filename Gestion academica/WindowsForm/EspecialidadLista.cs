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
    public partial class EspecialidadLista : Form
    {
        public EspecialidadLista()
        {
            InitializeComponent();
            ConfiguarColumnas();
        }

        private void ConfiguarColumnas()
        {
            especialidadesDataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "IDEspecialidad";
            idColumn.HeaderText = "ID";
            idColumn.Width = 50;
            especialidadesDataGridView.Columns.Add(idColumn);
            DataGridViewTextBoxColumn descripcionColumn = new DataGridViewTextBoxColumn();
            descripcionColumn.DataPropertyName = "Descripcion";
            descripcionColumn.HeaderText = "Descripción";
            descripcionColumn.Width = 200;
            especialidadesDataGridView.Columns.Add(descripcionColumn);
        }
        private void EspecialidadLista_Load(object sender, EventArgs e)
        {
            this.GetByCriteriaAndLoad();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

        }

        private void especialidadesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void modificarButton_click(object sender, EventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {

        }
        private async void GetByCriteriaAndLoad(string texto = "")
        {
            try
            {
                this.especialidadesDataGridView.DataSource = null;
                IEnumerable<EspecialidadDTO> especialidades;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    especialidades = await EspecialidadApi.GetAllAsync();
                }
                else
                {
                    especialidades = await EspecialidadApi.GetByCriteriaAsync(texto);
                }

                this.especialidadesDataGridView.DataSource = especialidades;
                if (this.especialidadesDataGridView.Rows.Count > 0)
                {
                    this.especialidadesDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }
    }
}
