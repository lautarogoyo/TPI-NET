using System.Text.RegularExpressions;
namespace Domain.Model
{
    public class Especialidad
    {
        public int IDEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public Especialidad(int id, string descripcion)
        {
            SetID(id);
            SetDescripcion(descripcion);
        }
        public void SetID(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que 0.", nameof(id));
            IDEspecialidad = id;
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}
    