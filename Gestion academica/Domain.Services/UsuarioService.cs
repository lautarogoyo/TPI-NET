using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class UsuarioService
    {
        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var repo = new UsuarioRepository();
            var usuario = new Usuario(dto.NombreUsuario, dto.Clave, dto.Habilitado,
                                      dto.Nombre, dto.Apellido, dto.Email,
                                      dto.CambiaClave, dto.IDPersona);
            repo.Add(usuario);
            dto.IDUsuario = usuario.IDUsuario;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new UsuarioRepository();
            return repo.Delete(id);
        }

        public UsuarioDTO? Get(int id)
        {
            var repo = new UsuarioRepository();
            var usuario = repo.Get(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                IDUsuario = usuario.IDUsuario,
                NombreUsuario = usuario.NombreUsuario,
                Clave = usuario.Clave,
                Habilitado = usuario.Habilitado,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                CambiaClave = usuario.CambiaClave,
                IDPersona = usuario.IDPersona
            };
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var repo = new UsuarioRepository();
            return repo.GetAll().Select(u => new UsuarioDTO
            {
                IDUsuario = u.IDUsuario,
                NombreUsuario = u.NombreUsuario,
                Clave = u.Clave,
                Habilitado = u.Habilitado,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                CambiaClave = u.CambiaClave,
                IDPersona = u.IDPersona
            }).ToList();
        }

        public bool Update(UsuarioDTO dto)
        {
            var repo = new UsuarioRepository();
            var usuario = new Usuario(dto.NombreUsuario, dto.Clave, dto.Habilitado,
                                      dto.Nombre, dto.Apellido, dto.Email,
                                      dto.CambiaClave, dto.IDPersona);

            typeof(Usuario).GetProperty(nameof(Usuario.IDUsuario))!
                           .SetValue(usuario, dto.IDUsuario);

            return repo.Update(usuario);
        }
    }
}
