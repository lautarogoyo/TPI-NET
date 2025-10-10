namespace Domain.Model
{
    public class Curso
    {
        // === PK ===
        public int IdCurso { get; private set; }

        // === Datos ===
        public int AnioCalendario { get; private set; }
        public int Cupo { get; private set; }
        public string Descripcion { get; private set; }
        public int IDComision { get; private set; }
        public int IDMateria { get; private set; }

        public Comision Comision { get; private set; }
        public Materia Materia { get; private set; }

        // === Navegaciones ===
        public ICollection<DocenteCurso> DocenteCursos { get; } = new List<DocenteCurso>();
        public ICollection<AlumnoInscripcion> AlumnoInscripciones = new List<AlumnoInscripcion>();

        // EF necesita ctor vacío
        private Curso() { }

        public Curso(int anio, int cupo, string descripcion, int idcomision, int idmateria)
        {
            SetAnio(anio);
            SetCupo(cupo);
            SetDescripcion(descripcion);
            SetIDComision(idcomision);
            SetIDMateria(idmateria);
        }

        public void SetAnio(int anio)
        {
            if (anio <= 0) throw new ArgumentException("El año debe ser mayor que 0.", nameof(anio));
            AnioCalendario = anio;
        }
        public void SetCupo(int cupo)
        {
            if (cupo <= 0) throw new ArgumentException("El cupo debe ser mayor que 0.", nameof(cupo));
            Cupo = cupo;
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
        public void SetIDComision(int idcomision)
        {
            if (idcomision <= 0) throw new ArgumentException("El ID de la comisión debe ser mayor que 0.", nameof(idcomision));
            IDComision = idcomision;
        }
        public void SetIDMateria(int idmateria)
        {
            if (idmateria <= 0) throw new ArgumentException("El ID de la materia debe ser mayor que 0.", nameof(idmateria));
            IDMateria = idmateria;
        }
    }
}
