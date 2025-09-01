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

        public bool Delete(int idCurso, int idDocente)
        {
            using var context = CreateContext();
            var dictado = context.DocentesCursos
                .FirstOrDefault(dc => dc.IDCurso == idCurso && dc.IDDocente == idDocente);

            if (dictado != null)
            {
                context.DocentesCursos.Remove(dictado);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public DocenteCurso? Get(int idCurso, int idDocente)
        {
            using var context = CreateContext();
            return context.DocentesCursos
                .FirstOrDefault(dc => dc.IDCurso == idCurso && dc.IDDocente == idDocente);
        }

        public IEnumerable<DocenteCurso> GetAll()
        {
            using var context = CreateContext();
            return context.DocentesCursos.ToList();
        }

        public bool Update(DocenteCurso docenteCurso)
        {
            using var context = CreateContext();
            var existing = context.DocentesCursos
                .FirstOrDefault(dc => dc.IDCurso == docenteCurso.IDCurso && dc.IDDocente == docenteCurso.IDDocente);

            if (existing != null)
            {
                existing.SetCargo(docenteCurso.Cargo);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
