using Domain.Model;

namespace Data
{
    public class DocenteCursoInMemory
    {
        public static List<DocenteCurso> DocentesCurso;

        static DocenteCursoInMemory()
        {
            DocentesCurso = new List<DocenteCurso>
            {
                new DocenteCurso(TiposCargos.Titular, 101, 1),
                new DocenteCurso(TiposCargos.Adjunto, 101, 2),
                new DocenteCurso(TiposCargos.JTP, 102, 3),
                new DocenteCurso(TiposCargos.Ayudante, 103, 4)
            };
        }
    }
}