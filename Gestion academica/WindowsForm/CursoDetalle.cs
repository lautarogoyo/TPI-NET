using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;
using Data;




namespace WindowsForm
{
    public partial class CursoDetalle : Form
    {
        private Curso _cursoExistente;

        public CursoDetalle()
        {
            InitializeComponent();
        }

        public CursoDetalle(Curso curso) : this()
        {
            _cursoExistente = curso;

            // Mostrar los datos en los controles
            IdTextBox.Text = curso.IdCurso.ToString();
            añocalendarioTextBox.Text = curso.AnioCalendario.ToString();
            cupoTextBox.Text = curso.Cupo.ToString();
            descripcionTextBox.Text = curso.Descripcion;
            comisionComboBox.SelectedValue = curso.IDComision;
            materiaComboBox.SelectedValue = curso.IDMateria;
        }



        private void CursoDetalle_Load(object sender, EventArgs e)
        {
            // Si querés cargar combos reales, adaptá según tengas Comisiones/Materias
            using (var context = new TPIContext())
            {
                comisionComboBox.DataSource = context.Planes.ToList(); // o context.Comisiones
                comisionComboBox.DisplayMember = "IDPlan";             // cambiar por nombre real si querés
                comisionComboBox.ValueMember = "IDPlan";

                materiaComboBox.DataSource = context.Planes.ToList(); // o context.Materias
                materiaComboBox.DisplayMember = "IDPlan";
                materiaComboBox.ValueMember = "IDPlan";
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = int.Parse(añocalendarioTextBox.Text);
                int cupo = int.Parse(cupoTextBox.Text);
                string descripcion = descripcionTextBox.Text;
                int idComision = Convert.ToInt32(comisionComboBox.SelectedValue);
                int idMateria = Convert.ToInt32(materiaComboBox.SelectedValue);

                using (var context = new TPIContext())
                {
                    if (_cursoExistente == null)
                    {
                        var nuevoCurso = new Curso(anio, cupo, descripcion, idComision, idMateria);
                        context.Cursos.Add(nuevoCurso);
                    }
                    else
                    {
                        var cursoDb = context.Cursos.Find(_cursoExistente.IdCurso);
                        if (cursoDb != null)
                        {
                            cursoDb.SetAnio(anio);
                            cursoDb.SetCupo(cupo);
                            cursoDb.SetDescripcion(descripcion);
                            cursoDb.SetIDComision(idComision);
                            cursoDb.SetIDMateria(idMateria);
                        }
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Curso guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el curso: " + ex.Message);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


/*                          COMENTARIO HASTA CREAR MATERIA Y COMISIONES EN BD
 using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WindowsForm
{
    public enum FormMode
    {
        Add,
        Update
    }

    public partial class CursoDetalle : Form
    {
        private CursoDTO curso;
        private FormMode mode;

        public CursoDTO Curso
        {
            get { return curso; }
            set
            {
                curso = value;
                this.SetCurso();
            }
        }

        public FormMode Mode
        {
            get { return mode; }
            set { SetFormMode(value); }
        }

        public CursoDetalle()
        {
            InitializeComponent();
            LoadCombos();
            Mode = FormMode.Add;
        }

        private async void LoadCombos()
        {
            try
            {
                var comisiones = await ComisionApiClient.GetAllAsync();
                comisionComboBox.DataSource = comisiones.ToList();
                comisionComboBox.DisplayMember = "Nombre";
                comisionComboBox.ValueMember = "Id";
                comisionComboBox.SelectedIndex = -1;

                var materias = await MateriaApiClient.GetAllAsync();
                materiaComboBox.DataSource = materias.ToList();
                materiaComboBox.DisplayMember = "Nombre";
                materiaComboBox.ValueMember = "Id";
                materiaComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void aceptarBoton_Click(object sender, EventArgs e)
        {
            if (this.ValidateCurso())
            {
                try
                {
                    this.Curso.Descripcion = descripcionTextBox.Text;
                    this.Curso.AnioCalendario = int.Parse(añocalendarioTextBox.Text);
                    this.Curso.Cupo = int.Parse(cupoTextBox.Text);
                    this.Curso.IDComision = (int)comisionComboBox.SelectedValue;
                    this.Curso.IDMateria = (int)materiaComboBox.SelectedValue;

                    if (this.Mode == FormMode.Update)
                        await CursoApiClient.UpdateAsync(this.Curso);
                    else
                        await CursoApiClient.AddAsync(this.Curso);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelarBoton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCurso()
        {
            this.idTextBox.Text = this.Curso.IdCurso.ToString();
            this.descripcionTextBox.Text = this.Curso.Descripcion;
            this.añocalendarioTextBox.Text = this.Curso.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Curso.Cupo.ToString();
            this.comisionComboBox.SelectedValue = this.Curso.IDComision;
            this.materiaComboBox.SelectedValue = this.Curso.IDMateria;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                idLabel.Visible = true;
                idTextBox.Visible = true;
            }
        }

        private bool ValidateCurso()
        {
            bool isValid = true;

            errorProvider.SetError(descripcionTextBox, string.Empty);
            errorProvider.SetError(añocalendarioTextBox, string.Empty);
            errorProvider.SetError(cupoTextBox, string.Empty);
            errorProvider.SetError(comisionComboBox, string.Empty);
            errorProvider.SetError(materiaComboBox, string.Empty);

            if (descripcionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(descripcionTextBox, "La descripción es requerida");
            }

            if (!int.TryParse(añocalendarioTextBox.Text, out _))
            {
                isValid = false;
                errorProvider.SetError(añocalendarioTextBox, "Debe ser un número válido");
            }

            if (!int.TryParse(cupoTextBox.Text, out _))
            {
                isValid = false;
                errorProvider.SetError(cupoTextBox, "Debe ser un número válido");
            }

            if (comisionComboBox.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(comisionComboBox, "Debe seleccionar una comisión");
            }

            if (materiaComboBox.SelectedValue == null)
            {
                isValid = false;
                errorProvider.SetError(materiaComboBox, "Debe seleccionar una materia");
            }

            return isValid;
        }

        private void CursoDetalle_Load(object sender, EventArgs e)
        {
        }
    }
}


*/