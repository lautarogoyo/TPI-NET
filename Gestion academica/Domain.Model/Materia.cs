namespace Domain.Model
{
    public class Materia
    {
        // === PK ===
        public int IDMateria { get; private set; }

        // === Datos ===
        public string Descripcion { get; private set; }

        public ICollection<Curso> Cursos { get; private set; } = new List<Curso>();
        
        /*
        public int HSSemanales { get; private set; }
        public int HSTotales { get; private set; }
        public int IDPlan { get; private set; }
        */

        // === Navegaciones ===
        // (Si más adelante agregás navegación a Cursos, podría ir: public ICollection<Curso> Cursos { get; } = new List<Curso>();)

        // EF necesita ctor vacío
        private Materia() { }

        public Materia(string descripcion /*,int hsSemanales, int hsTotales, int idPlan*/)
        {
            SetDescripcion(descripcion);
            /*
            SetHSSemanales(hsSemanales);
            SetHSTotales(hsTotales);
            SetIDPlan(idPlan);
            */
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }

        /*
        public void SetHSSemanales(int hsSemanales)
        {
            if (hsSemanales <= 0) throw new ArgumentException("Las horas semanales deben ser mayores que 0.", nameof(hsSemanales));
            HSSemanales = hsSemanales;
        }

        public void SetHSTotales(int hsTotales)
        {
            if (hsTotales <= 0) throw new ArgumentException("Las horas totales deben ser mayores que 0.", nameof(hsTotales));
            HSTotales = hsTotales;
        }

        public void SetIDPlan(int idPlan)
        {
            if (idPlan <= 0) throw new ArgumentException("El ID del plan debe ser mayor que 0.", nameof(idPlan));
            IDPlan = idPlan;
        }
        */
    }
}
