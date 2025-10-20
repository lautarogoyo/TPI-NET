using Domain.Model;
using Microsoft.EntityFrameworkCore;

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
                existing.SetIDPersona(usuario.IDPersona);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Usuario> GetAllWithPersonas()
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .ToList();
        }
        public Usuario? GetByNombreUsuario(string nombreUsuario)
        {
            using var context = CreateContext();
            return context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }
        public Usuario? GetByNombreUsuarioNormalized(string nombreUsuario)
        {
            var normalized = (nombreUsuario ?? string.Empty).Trim().ToLower();
            using var context = CreateContext();
            return context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario.ToLower().Trim() == normalized);
        }

    }
}
