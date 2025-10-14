namespace Domain.Model
{
    public class Comision
    {
        // === PK ===
        public int IDComision { get; private set; }

        // === Datos ===
        public string Descripcion { get; private set; }
        public int AnioEspecialidad { get; private set; }
        public int IDPlan { get; private set; }
        public Plan Plan { get; private set; }

        public ICollection<ComisionMateria> ComisionesMaterias { get; private set; } = new List<ComisionMateria>();


        // EF necesita ctor vacío
        private Comision() { }

        public Comision(string descripcion, int anioEspecialidad, int idPlan)
        {
            SetDescripcion(descripcion);
            SetAnioEspecialidad(anioEspecialidad);
            SetIDPlan(idPlan);
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        public void SetAnioEspecialidad(int anioEspecialidad)
        {
            if (anioEspecialidad <= 0) throw new ArgumentException("El año de especialidad debe ser mayor que 0.", nameof(anioEspecialidad));
            AnioEspecialidad = anioEspecialidad;
        }

        public void SetIDPlan(int idPlan)
        {
            if (idPlan <= 0) throw new ArgumentException("El ID del plan debe ser mayor que 0.", nameof(idPlan));
            IDPlan = idPlan;
        }
    }
}
