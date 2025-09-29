using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Materia materia)
        {
            using var context = CreateContext();
            context.Materias.Add(materia);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var materia = context.Materias.Find(id);
            if (materia != null)
            {
                context.Materias.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Materia? Get(int id)
        {
            using var context = CreateContext();
            return context.Materias.Find(id);
        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materias.ToList();
        }

        public bool Update(Materia materia)
        {
            using var context = CreateContext();
            var existingMateria = context.Materias.Find(materia.IDMateria);
            if (existingMateria != null)
            {
                existingMateria.SetDescripcion(materia.Descripcion);
                /*
                existingMateria.SetHSSemanales(materia.HSSemanales);
                existingMateria.SetHSTotales(materia.HSTotales);
                existingMateria.SetIDPlan(materia.IDPlan);
                */

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
