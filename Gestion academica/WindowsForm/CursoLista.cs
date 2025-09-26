using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;

namespace WindowsForm
{
    public partial class CursoLista : Form
    {
        public CursoLista()
        {
            InitializeComponent();
        }

        private void CursoLista_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CursoDetalle cursoDetalle = new CursoDetalle();

            CursoDTO cursoNuevo = new CursoDTO();

            if (cursoDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
