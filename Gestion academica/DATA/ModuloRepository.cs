using Domain.Model;

namespace Data
{
    public class ModuloRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Modulo modulo)
        {
            using var context = CreateContext();
            context.Modulos.Add(modulo);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var modulo = context.Modulos.Find(id);
            if (modulo != null)
            {
                context.Modulos.Remove(modulo);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Modulo? Get(int id)
        {
            using var context = CreateContext();
            return context.Modulos.Find(id);
        }

        public IEnumerable<Modulo> GetAll()
        {
            using var context = CreateContext();
            return context.Modulos.ToList();
        }

        public bool Update(Modulo modulo)
        {
            using var context = CreateContext();
            var existing = context.Modulos.Find(modulo.IDModulo);
            if (existing != null)
            {
                existing.SetDescripcion(modulo.DescModulo);
                existing.SetEjecuta(modulo.Ejecuta);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
