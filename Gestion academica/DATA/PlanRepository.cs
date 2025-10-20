using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Plan plan)
        {
            using var context = CreateContext();
            context.Planes.Add(plan);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var plan = context.Planes.Find(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Plan? Get(int id)
        {
            using var context = CreateContext();
            return context.Planes.Find(id);
        }

        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Planes.Include(p => p.Especialidad).ToList();
        }

        public bool Update(Plan plan)
        {
            using var context = CreateContext();
            var existing = context.Planes.Find(plan.IDPlan);
            if (existing != null)
            {
                existing.SetDescripcion(plan.DescPlan);
                existing.SetIDEspecialidad(plan.IDEspecialidad);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ExistePlanConEspecialidad(int idEspecialidad)
        {
            using var context = CreateContext();
            return context.Planes.Any(p => p.IDEspecialidad == idEspecialidad);
        }
    }
}
