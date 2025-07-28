using System.Text.RegularExpressions;

namespace DTOs
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Materia { get; set; }

    }
}