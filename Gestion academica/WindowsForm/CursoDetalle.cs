using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForm
{
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
                SetCurso();
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
        }

        private async void CursoDetalle_Load(object sender, EventArgs e)
        {
            await LoadCombos();
        }

        private async Task LoadCombos()
        {
            try
            {
                var comisiones = await ComisionApi.GetAllAsync();
                comisionComboBox.DataSource = comisiones;
                comisionComboBox.DisplayMember = "Descripcion";
                comisionComboBox.ValueMember = "IDComision";
                comisionComboBox.SelectedIndex = -1;

                var materias = await MateriaApi.GetAllAsync();
                materiaComboBox.DataSource = materias;
                materiaComboBox.DisplayMember = "Descripcion";
                materiaComboBox.ValueMember = "IDMateria";
                materiaComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (!ValidateCurso()) return;

            try
            {
                this.Curso ??= new CursoDTO();
                this.Curso.Descripcion = descripcionTextBox.Text;
                this.Curso.AnioCalendario = int.Parse(añocalendarioTextBox.Text);
                this.Curso.Cupo = int.Parse(cupoTextBox.Text);
                this.Curso.IDComision = (int)comisionComboBox.SelectedValue;
                this.Curso.IDMateria = (int)materiaComboBox.SelectedValue;

                if (this.Mode == FormMode.Update)
                {
                    if (this.Curso.IdCurso <= 0)
                        throw new InvalidOperationException("ID de curso inválido (<= 0).");

                    await CursoApi.UpdateAsync(this.Curso);
                }
                else
                {
                    await CursoApi.AddAsync(this.Curso);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (mode == FormMode.Add)
            {
                this.Text = "Agregar Curso";
                if (this.Curso == null)
                    this.Curso = new CursoDTO();

                IdTextBox.Text = string.Empty;
                descripcionTextBox.Text = string.Empty;
                añocalendarioTextBox.Text = string.Empty;
                cupoTextBox.Text = string.Empty;
                comisionComboBox.SelectedIndex = -1;
                materiaComboBox.SelectedIndex = -1;
            }
            else
            {
                this.Text = "Modificar Curso";
                SetCurso();
            }
        }

        private void SetCurso()
        {
            if (this.Curso == null) return;

            IdTextBox.Text = this.Curso.IdCurso.ToString();
            descripcionTextBox.Text = this.Curso.Descripcion;
            añocalendarioTextBox.Text = this.Curso.AnioCalendario.ToString();
            cupoTextBox.Text = this.Curso.Cupo.ToString();
            comisionComboBox.SelectedValue = this.Curso.IDComision;
            materiaComboBox.SelectedValue = this.Curso.IDMateria;
        }

        private bool ValidateCurso()
        {
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(añocalendarioTextBox.Text, out _))
            {
                MessageBox.Show("Año calendario inválido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(cupoTextBox.Text, out _))
            {
                MessageBox.Show("Cupo inválido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comisionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una comisión.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (materiaComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una materia.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}



