using Domain.Model;

namespace Data
{
    public class AlumnoInscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();
            context.AlumnosInscripciones.Add(inscripcion);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var entity = context.AlumnosInscripciones.Find(id);
            if (entity != null)
            {
                context.AlumnosInscripciones.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public AlumnoInscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.Find(id);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.ToList();
        }

        public bool Update(AlumnoInscripcion inscripcion)
        {
            using var context = CreateContext();
            var existing = context.AlumnosInscripciones.Find(inscripcion.IDInscripcion);
            if (existing != null)
            {
                existing.SetIDAlumno(inscripcion.IDAlumno);
                existing.SetIDCurso(inscripcion.IDCurso);
                existing.SetCondicion(inscripcion.Condicion);
                existing.SetNota(inscripcion.Nota);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
