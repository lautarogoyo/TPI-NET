namespace Domain.Model
{
    public class Inscripcion
    {
        public int IDInscripcion { get; private set; }
        public int IDAlumno { get; private set; }
        public int IDCurso { get; private set; }
        public string Condicion { get; private set; }
        public int NotaFinal { get; private set; }

        public Curso Curso { get; private set; } // navegación
        public Persona Alumno { get; private set; } // navegación

        private Inscripcion() { }

        public Inscripcion(int idAlumno, int idCurso, string condicion, int notaFinal)
        {
            SetIDAlumno(idAlumno);
            SetIDCurso(idCurso);
            SetCondicion(condicion);
            SetNotaFinal(notaFinal);
        }

        public void SetIDAlumno(int idAlumno) => IDAlumno = idAlumno;
        public void SetIDCurso(int idCurso) => IDCurso = idCurso;
        public void SetCondicion(string condicion) => Condicion = condicion;
        public void SetNotaFinal(int notaFinal) => NotaFinal = notaFinal;
    }
}
