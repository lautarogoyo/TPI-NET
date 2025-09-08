using System.Text.RegularExpressions;
namespace Domain.Model
{
    public class Especialidad
    {
        public int IDEspecialidad { get; private set; }
        public string Descripcion { get; private set; }

        // Constructor para EF
        protected Especialidad() { }

        // Constructor para crear nueva
        public Especialidad(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }
    }

}
