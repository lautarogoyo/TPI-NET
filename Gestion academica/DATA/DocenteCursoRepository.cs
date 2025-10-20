using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DocenteCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            context.DocentesCursos.Add(docenteCurso);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var docenteCurso = context.DocentesCursos.Find(id);
            if (docenteCurso != null)
            {
                context.DocentesCursos.Remove(docenteCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public DocenteCurso? Get(int id)
        {
            using var context = CreateContext();
            return context.DocentesCursos.Find(id);
        }

        public IEnumerable<DocenteCurso> GetAll()
        {
            using var context = CreateContext();
            return context.DocentesCursos
                .Include(dc => dc.Curso)
                .Include(dc => dc.Docente)
                .ToList();
        }

        public bool Update(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            var existingDC = context.DocentesCursos.Find(docenteCurso.IdDocenteCurso);
            if (existingDC != null)
            {
                existingDC.SetCargo(docenteCurso.Cargo);
                existingDC.SetIDCurso(docenteCurso.IDCurso);
                existingDC.SetIDDocente(docenteCurso.IDDocente);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
