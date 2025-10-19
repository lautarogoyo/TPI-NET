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
            var usuario = new Usuario(dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.IDPersona);
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
                IDPersona = u.IDPersona
            }).ToList();
        }

        public bool Update(UsuarioDTO dto)
        {
            var repo = new UsuarioRepository();
            var usuario = repo.Get(dto.IDUsuario);
            if (usuario == null) return false;

            usuario.SetNombreUsuario(dto.NombreUsuario);
            usuario.SetClave(dto.Clave);
            usuario.SetHabilitado(dto.Habilitado);
            usuario.SetIDPersona(dto.IDPersona);

            return repo.Update(usuario);
        }
        public IEnumerable<UsuarioDTO> GetAllWithPersonas()
        {
            var repo = new UsuarioRepository();
            return repo.GetAllWithPersonas().Select(u => new UsuarioDTO
            {
                IDUsuario = u.IDUsuario,
                NombreUsuario = u.NombreUsuario,
                Clave = u.Clave,
                Habilitado = u.Habilitado,
                IDPersona = u.IDPersona,
                NombreApellidoPersona = $"{u.Persona.Nombre} {u.Persona.Apellido}",
                Legajo = u.Persona.Legajo,
                TipoPersona = u.Persona.TipoPersona
            }).ToList();
        }
    }
}
