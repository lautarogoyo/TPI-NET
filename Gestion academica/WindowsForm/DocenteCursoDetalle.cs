using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WindowsForm
{
    public partial class DocenteCursoDetalle : Form
    {
        private DocenteCursoDTO? docenteCurso;
        private FormMode mode;
        private List<CursoDTO> cursos = new();
        private List<PersonaDTO> docentes = new();

        public DocenteCursoDTO DocenteCurso
        {
            get => docenteCurso!;
            set { docenteCurso = value; SetDocenteCurso(); }
        }

        public FormMode Mode
        {
            get => mode;
            set { SetFormMode(value); }
        }

        public DocenteCursoDetalle()
        {
            InitializeComponent();
            this.Load += DocenteCursoDetalle_Load;
        }

        private async void DocenteCursoDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                
                cursos = (await CursoApi.GetAllAsync()).ToList();
                comboBoxCurso.DataSource = cursos;
                comboBoxCurso.DisplayMember = "Descripcion";
                comboBoxCurso.ValueMember = "IDCurso";
                comboBoxCurso.SelectedIndex = -1;

                docentes = (await PersonaApi.GetAllAsync())
                    .Where(p => p.TipoPersona == 2)
                    .ToList();
                comboBoxDocente.DataSource = docentes;
                comboBoxDocente.DisplayMember = "NombreCompleto";
                comboBoxDocente.ValueMember = "IDPersona";
                comboBoxDocente.SelectedIndex = -1;

                
                comboBoxCargo.DataSource = Enum.GetValues(typeof(TiposCargos));

                
                if (docenteCurso != null)
                {
                    comboBoxCurso.SelectedValue = docenteCurso.IDCurso;
                    comboBoxDocente.SelectedValue = docenteCurso.IDDocente;
                    comboBoxCargo.SelectedItem = docenteCurso.Cargo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAceptar_Click(object? sender, EventArgs e)
        {
            if (!ValidateDocenteCurso()) return;

            try
            {
                docenteCurso ??= new DocenteCursoDTO();

                docenteCurso.Cargo = (TiposCargos)comboBoxCargo.SelectedItem!;
                docenteCurso.IDCurso = (int)comboBoxCurso.SelectedValue!;
                docenteCurso.IDDocente = (int)comboBoxDocente.SelectedValue!;

                var existing = (await DocenteCursoApi.GetAllAsync())
                    .FirstOrDefault(dc =>
                    dc.IDDocente == (int)comboBoxDocente.SelectedValue &&
                    dc.IDCurso == (int)comboBoxCurso.SelectedValue);

                if(existing == null)
                {
                    if (Mode == FormMode.Update)
                        await DocenteCursoApi.UpdateAsync(docenteCurso);
                    else
                        await DocenteCursoApi.AddAsync(docenteCurso);
                }
                else
                {
                    MessageBox.Show("Este docente ya está asignado al curso.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Cambios guardados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateDocenteCurso()
        {
            if (comboBoxCargo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cargo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBoxCurso.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un curso.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBoxDocente.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un docente.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
            Text = (mode == FormMode.Add)
                ? "Agregar Docente-Curso"
                : "Modificar Docente-Curso";
        }

        private void SetDocenteCurso()
        {
            if (docenteCurso != null)
            {
                comboBoxCargo.SelectedItem = docenteCurso.Cargo;
                comboBoxCurso.SelectedValue = docenteCurso.IDCurso;
                comboBoxDocente.SelectedValue = docenteCurso.IDDocente;
            }
        }
    }
}
