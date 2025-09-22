namespace Domain.Model
{
    public class Plan
    {
        public int IDPlan { get; private set; }
        public string DescPlan { get; private set; }
        public int IDEspecialidad { get; private set; }

        // Constructor para EF
        protected Plan() { }

        // Constructor para crear nuevo Plan
        public Plan(string descPlan, int idEspecialidad)
        {
            DescPlan = descPlan;
            IDEspecialidad = idEspecialidad;
        }

        public void SetDescripcion(string descPlan) => DescPlan = descPlan;
        public void SetIDEspecialidad(int idEspecialidad) => IDEspecialidad = idEspecialidad;
    }
}
