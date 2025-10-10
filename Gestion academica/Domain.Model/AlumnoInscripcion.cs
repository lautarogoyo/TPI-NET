namespace Domain.Model
{
    public class AlumnoInscripcion
    {
        public int IDInscripcion { get; private set; }
        public int IDAlumno { get; private set; }
        public int IDCurso { get; private set; }
        public string Condicion { get; private set; }
        public int Nota { get; private set; }

        public Curso Curso { get; private set; } // navegación
        public Persona Alumno { get; private set; } // navegación

        protected AlumnoInscripcion() { }

        public AlumnoInscripcion(int idAlumno, int idCurso, string condicion, int nota)
        {
            IDAlumno = idAlumno;
            IDCurso = idCurso;
            Condicion = condicion;
            Nota = nota;
        }

        public void SetIDAlumno(int idAlumno) => IDAlumno = idAlumno;
        public void SetIDCurso(int idCurso) => IDCurso = idCurso;
        public void SetCondicion(string condicion) => Condicion = condicion;
        public void SetNota(int nota) => Nota = nota;
    }
}
