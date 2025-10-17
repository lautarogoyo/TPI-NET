using Domain.Model;

namespace Data
{
    public class InscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            context.Inscripciones.Add(inscripcion);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var inscripcion = context.Inscripciones.Find(id);
            if (inscripcion != null)
            {
                context.Inscripciones.Remove(inscripcion);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Inscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.Inscripciones.Find(id);
        }

        public IEnumerable<Inscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.Inscripciones.ToList();
        }

        public bool Update(Inscripcion inscripcion)
        {
            using var context = CreateContext();
            var existing = context.Inscripciones.Find(inscripcion.IDInscripcion);
            if (existing != null)
            {
                existing.SetIDAlumno(inscripcion.IDAlumno);
                existing.SetIDCurso(inscripcion.IDCurso);
                existing.SetCondicion(inscripcion.Condicion);
                existing.SetNotaFinal(inscripcion.NotaFinal);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
