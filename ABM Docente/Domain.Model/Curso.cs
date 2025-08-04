using System.Text.RegularExpressions;
namespace Domain.Model
{
    public class Curso
    {
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public string Descripcion { get; set; }
        public int IDComision { get; set; }
        public int IDMateria { get; set; }

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
            if (anio <= 0)
                throw new ArgumentException("El año debe ser mayor que 0.", nameof(anio));
            AnioCalendario = anio;
        }
        public void SetCupo(int cupo)
        {
            if (cupo <= 0)
                throw new ArgumentException("El cupo debe ser mayor que 0.", nameof(cupo));
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
            if (idcomision <= 0)
                throw new ArgumentException("El ID de la comisión debe ser mayor que 0.", nameof(idcomision));
            IDComision = idcomision;
        }
        public void SetIDMateria(int idmateria)
        {
            if (idmateria <= 0)
                throw new ArgumentException("El ID de la materia debe ser mayor que 0.", nameof(idmateria));
            IDMateria = idmateria;
        }
    }
}