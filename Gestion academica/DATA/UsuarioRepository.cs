using Domain.Model;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios.ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existing = context.Usuarios.Find(usuario.IDUsuario);
            if (existing != null)
            {
                existing.SetNombreUsuario(usuario.NombreUsuario);
                existing.SetClave(usuario.Clave);
                existing.SetHabilitado(usuario.Habilitado);
                existing.SetNombre(usuario.Nombre);
                existing.SetApellido(usuario.Apellido);
                existing.SetEmail(usuario.Email);
                existing.SetCambiaClave(usuario.CambiaClave);
                existing.SetIDPersona(usuario.IDPersona);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
