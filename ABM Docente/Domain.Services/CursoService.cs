using DATA;
using Domain.Model;

namespace Domain.Services
{
    public class CursoService
    {
        public void Add(Curso curso)
        {
            CursoInMemory.Curso.Add(curso);
        }

        public bool Delete(int idcomision, int idmateria)
        {
            var item = CursoInMemory.Curso
                .FirstOrDefault(x => x.IDComision == idcomision && x.IDMateria == idmateria);

            if (item != null)
            {
                CursoInMemory.Curso.Remove(item);
                return true;
            }

            return false;
        }

        public Curso? Get(int idcomision, int idmateria)
        {
            return CursoInMemory.Curso
                .FirstOrDefault(x => x.IDComision == idcomision && x.IDMateria == idmateria);
        }

        public IEnumerable<Curso> GetAll()
        {
            return CursoInMemory.Curso.ToList();
        }

        public bool Update(Curso updated)
        {
            var current = CursoInMemory.Curso
                .FirstOrDefault(x => x.IDComision == updated.IDComision && x.IDMateria == updated.IDMateria );

            if (current != null)
            {
                current.SetAnio(updated.AnioCalendario);
                current.SetCupo(updated.Cupo);
                current.SetDescripcion(updated.Descripcion);
                current.SetIDComision(updated.IDComision);
                current.SetIDMateria(updated.IDMateria);
                return true;
            }

            return false;
        }
    }
}