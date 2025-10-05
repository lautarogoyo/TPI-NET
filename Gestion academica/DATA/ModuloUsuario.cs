using Domain.Model;

namespace Data
{
    public class ModuloUsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(ModuloUsuario entidad)
        {
            using var context = CreateContext();
            context.ModulosUsuarios.Add(entidad);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var entidad = context.ModulosUsuarios.Find(id);
            if (entidad != null)
            {
                context.ModulosUsuarios.Remove(entidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ModuloUsuario? Get(int id)
        {
            using var context = CreateContext();
            return context.ModulosUsuarios.Find(id);
        }

        public IEnumerable<ModuloUsuario> GetAll()
        {
            using var context = CreateContext();
            return context.ModulosUsuarios.ToList();
        }

        public bool Update(ModuloUsuario entidad)
        {
            using var context = CreateContext();
            var existing = context.ModulosUsuarios.Find(entidad.IDModuloUsuario);
            if (existing != null)
            {
                existing.SetIDModulo(entidad.IDModulo);
                existing.SetIDUsuario(entidad.IDUsuario);
                existing.SetPermisos(entidad.Alta, entidad.Baja, entidad.Modificacion, entidad.Consulta);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
