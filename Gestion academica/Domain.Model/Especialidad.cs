using System.Text.RegularExpressions;
namespace Domain.Model
{
    public class Especialidad
    {
        public int IDEspecialidad { get; private set; }
        public string Descripcion { get; private set; }
        public ICollection<Plan> Planes { get; private set; } = new List<Plan>();

        // Constructor para EF
        protected Especialidad() { }

        // Constructor para crear nueva
        public Especialidad(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");
            Descripcion = descripcion;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");
            Descripcion = descripcion;
        }
    }

}
