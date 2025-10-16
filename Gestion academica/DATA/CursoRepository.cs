using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Curso curso)
        {
            using var context = CreateContext();
            context.Cursos.Add(curso);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Curso? Get(int id)
        {
            using var context = CreateContext();
            return context.Cursos.Find(id);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Cursos.ToList();
        }

        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.IdCurso);
            if (existingCurso != null)
            {
                existingCurso.SetAnio(curso.AnioCalendario);
                existingCurso.SetCupo(curso.Cupo);
                existingCurso.SetDescripcion(curso.Descripcion);
                existingCurso.SetIDComisionMateria(curso.IDComisionMateria);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ExisteRelacionConComisionMateria(int idComisionMateria)
        {
            using var context = CreateContext();
            return context.Cursos.Any(c => c.IDComisionMateria == idComisionMateria);
        }

        public IEnumerable<Curso> GetWithComisionMateria()
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.ComisionMateria)
                .ThenInclude(cm => cm.Comision)
                .Include(c => c.ComisionMateria)
                .ThenInclude(cm => cm.Materia)
                .ToList();
        }
    }
}
