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
        public int IDComisionMateria { get; private set; }
        public ComisionMateria ComisionMateria { get; private set; }

        // === Navegaciones ===
        public ICollection<DocenteCurso> DocentesCursos { get; } = new List<DocenteCurso>();
        public ICollection<Inscripcion> Inscripciones { get; private set; } = new List<Inscripcion>();

        // EF necesita ctor vacío
        protected Curso() { }

        public Curso(int anio, int cupo, string descripcion, int idcomisionmateria)
        {
            SetAnio(anio);
            SetCupo(cupo);
            SetDescripcion(descripcion);
            SetIDComisionMateria(idcomisionmateria);
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
        public void SetIDComisionMateria(int idcomisionmateria)
        {
            if (idcomisionmateria <= 0) throw new ArgumentException("El ID de la comisiónMateria debe ser mayor que 0.", nameof(idcomisionmateria));
            IDComisionMateria = idcomisionmateria;
        }
     }
}
