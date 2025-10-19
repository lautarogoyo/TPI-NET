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

        private void especialidadButton_Click(object sender, EventArgs e)
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

        private void UsuarioButton_Click(object sender, EventArgs e)
        {
            UsuarioLista usuarioForm = new UsuarioLista();
            usuarioForm.ShowDialog();
        }

        private void alumnoButton_Click(object sender, EventArgs e)
        {
            int numeroPersona = 1;
            string tipoPersona = "alumno";
            PersonaLista personaForm = new PersonaLista(numeroPersona, tipoPersona);
            personaForm.ShowDialog();
        }
        private void profesorButton_Click(object sender, EventArgs e)
        {
            int numeroPersona = 2;
            string tipoPersona = "profesor";
            PersonaLista personaForm = new PersonaLista(numeroPersona, tipoPersona);
            personaForm.ShowDialog();
        }


        private void planButton_Click(object sender, EventArgs e)
        {
            PlanLista planForm = new PlanLista();
            planForm.ShowDialog();
        }

        private void comisionButton_Click(object sender, EventArgs e)
        {
            ComisionLista comisionForm = new ComisionLista();
            comisionForm.ShowDialog();
        }

        private void btnDocenteCurso_Click(object sender, EventArgs e)
        {
            DocenteCursoLista docentecursoFrom = new DocenteCursoLista();
            docentecursoFrom.ShowDialog();
        }
    }
}
