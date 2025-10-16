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
        private List<ComisionMateriaDTO> comisionesMaterias = new();
        private List<ComisionDTO> comisiones = new();
        private bool _isLoading = false;
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
        }

        private async void CursoDetalle_Load(object sender, EventArgs e)
        {
            await LoadComboxComision();
        }

        private async Task LoadComboxComision()
        {
            try
            {
                _isLoading = true;
                comisiones = (await ComisionApi.GetAllAsync()).ToList();
                comisionComboBox.DataSource = comisiones;
                comisionComboBox.DisplayMember = "Descripcion";
                comisionComboBox.ValueMember = "IDComision";
                comisionComboBox.SelectedIndex = -1;

                if (this.Curso != null && this.Curso.IDComisionMateria > 0)
                {
                    comisionComboBox.SelectedValue = this.Curso.IDComision;
                    await CargarMateriasPorComision(this.Curso.IDComision.Value);
                    materiaComboBox.SelectedValue = this.Curso.IDComisionMateria;

                }

                comisionComboBox.Enabled = (this.Mode == FormMode.Add);
                materiaComboBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false; 
            }

        }
        private async Task CargarMateriasPorComision(int idComision)
        {
            try
            {
                materiaComboBox.Enabled = true;
                comisionesMaterias = (await ComisionMateriaApi.GetByComisionAsync(idComision)).ToList();

                materiaComboBox.DataSource = comisionesMaterias;
                materiaComboBox.DisplayMember = "DescMateria";
                materiaComboBox.ValueMember = "IDComisionMateria";
                materiaComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var idMateria = (int?)materiaComboBox.SelectedValue;
                this.Curso.IDComisionMateria = idMateria.Value;

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
            if (this.Curso != null)
            {
                descripcionTextBox.Text = this.Curso.Descripcion;
                añocalendarioTextBox.Text = this.Curso.AnioCalendario.ToString();
                cupoTextBox.Text = this.Curso.Cupo.ToString();
                comisionComboBox.SelectedValue = this.Curso.IDComision;
                materiaComboBox.SelectedValue = this.Curso.IDComisionMateria;
            }
        }

        private bool ValidateCurso()
        {
            if (string.IsNullOrWhiteSpace(descripcionTextBox.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(añocalendarioTextBox.Text, out int a) || a <= 0)
            {
                MessageBox.Show("Las año debe ser válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(cupoTextBox.Text, out int c) || c <= 0)
            {
                MessageBox.Show("El cupo debe ser válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void comisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            if (comisionComboBox.SelectedValue == null) return;
            if (!int.TryParse(comisionComboBox.SelectedValue.ToString(), out int idComision))
                return;
            await CargarMateriasPorComision(idComision);
        }
    }
}



