using Domain.Model;

namespace Data
{
    public class EspecialidadInMemory
    {
        public static List<Especialidad> Especialidades;

        static EspecialidadInMemory()
        {
            Especialidades = new List<Especialidad>
            {
                new Especialidad(1, "Sistemas"),
                new Especialidad(2, "Civil"),
                new Especialidad(3, "Electrica"),
                new Especialidad(4, "Química")
            };
        }
    }
}