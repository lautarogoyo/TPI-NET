using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionMateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(ComisionMateria comisionMateria)
        {
            using var context = CreateContext();
            context.ComisionesMaterias.Add(comisionMateria);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var comisionMateria = context.ComisionesMaterias.Find(id);
            if (comisionMateria != null)
            {
                context.ComisionesMaterias.Remove(comisionMateria);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ComisionMateria? Get(int id)
        {
            using var context = CreateContext();
            return context.ComisionesMaterias.Find(id);
        }

        public IEnumerable<ComisionMateria> GetAll()
        {
            using var context = CreateContext();
            return context.ComisionesMaterias.ToList();
        }

        public bool Update(ComisionMateria comisionMateria)
        {
            using var context = CreateContext();
            var existingComisionMateria = context.ComisionesMaterias.Find(comisionMateria.IDComisionMateria);
            if (existingComisionMateria != null)
            {
                existingComisionMateria.SetHsSemanales(comisionMateria.HsSemanales);
                existingComisionMateria.SetHsTotales(comisionMateria.HsTotales);
                existingComisionMateria.SetIDComision(comisionMateria.IDComision);
                existingComisionMateria.SetIDMateria(comisionMateria.IDMateria);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ComisionMateria> GetByComision(int idComision)
        {
            using var context = CreateContext();
            return context.ComisionesMaterias
                .Include(cm => cm.Materia)
                .Where(cm => cm.IDComision == idComision)
                .ToList();
        }

    }
}

