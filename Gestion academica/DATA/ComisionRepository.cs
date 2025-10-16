using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Comision comision)
        {
            using var context = CreateContext();
            context.Comisiones.Add(comision);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var comision = context.Comisiones.Find(id);
            if (comision != null)
            {
                context.Comisiones.Remove(comision);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Comision? Get(int id)
        {
            using var context = CreateContext();
            return context.Comisiones.Find(id);
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Comisiones.ToList();
        }

        public bool Update(Comision comision)
        {
            using var context = CreateContext();
            var existingComision = context.Comisiones.Find(comision.IDComision);
            if (existingComision != null)
            {
                existingComision.SetDescripcion(comision.Descripcion);
                existingComision.SetAnioEspecialidad(comision.AnioEspecialidad);
                existingComision.SetIDPlan(comision.IDPlan);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ExisteComisionConPlan(int idPlan)
        {
            using var context = CreateContext();
            return context.Comisiones.Any(c => c.IDPlan == idPlan);
        }
    }
}
