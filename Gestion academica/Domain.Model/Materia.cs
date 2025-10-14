namespace Domain.Model
{
    public class Materia
    {
        // === PK ===
        public int IDMateria { get; private set; }

        // === Datos ===
        public string Descripcion { get; private set; }

        // EF necesita ctor vacío
        private Materia() { }

        public Materia(string descripcion)
        {
            SetDescripcion(descripcion);
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}
