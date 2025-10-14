namespace Domain.Model
{
    public class Plan
    {
        public int IDPlan { get; private set; }
        public string DescPlan { get; private set; }
        public int IDEspecialidad { get; private set; }

        public Especialidad Especialidad { get; private set; }   // navegación
        public ICollection<Comision> Comisiones { get; private set; } = new List<Comision>();


        // Constructor para EF
        protected Plan() { }

        // Constructor para crear nuevo Plan
        public Plan(string descPlan, int idEspecialidad)
        {
            if (string.IsNullOrWhiteSpace(descPlan))
                throw new ArgumentException("La descripción del plan no puede estar vacía.", nameof(descPlan));

            if (idEspecialidad <= 0)
                throw new ArgumentException("El ID de la especialidad debe ser mayor a cero.", nameof(idEspecialidad));

            DescPlan = descPlan;
            IDEspecialidad = idEspecialidad;
        }

        public void SetDescripcion(string descPlan)
        {
            if (string.IsNullOrWhiteSpace(descPlan))
                throw new ArgumentException("La descripción del plan no puede estar vacía.", nameof(descPlan));

            DescPlan = descPlan;
        }

        public void SetIDEspecialidad(int idEspecialidad)
        {
            if (idEspecialidad <= 0)
                throw new ArgumentException("El ID de la especialidad debe ser mayor a cero.", nameof(idEspecialidad));

            IDEspecialidad = idEspecialidad;
        }
    }
}
