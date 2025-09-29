using System;
using System.Windows.Forms;
using WindowsForm;

namespace WindowsForms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Especialidades(object sender, EventArgs e)
        {
            EspecialidadLista especialidadesForm = new EspecialidadLista();
            especialidadesForm.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void cursoButton_Click(object sender, EventArgs e)
        {
            CursoLista cursoForm = new CursoLista();
            cursoForm.ShowDialog();
        }

        private void materiaButton_Click(object sender, EventArgs e)
        {
            MateriaLista materiaForm = new MateriaLista();
            materiaForm.ShowDialog();
        }
    }
}
