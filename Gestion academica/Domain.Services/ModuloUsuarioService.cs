using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ModuloUsuarioService
    {
        public ModuloUsuarioDTO Add(ModuloUsuarioDTO dto)
        {
            var repo = new ModuloUsuarioRepository();
            var entidad = new ModuloUsuario(dto.IDModulo, dto.IDUsuario, dto.Alta, dto.Baja, dto.Modificacion, dto.Consulta);
            repo.Add(entidad);
            dto.IDModuloUsuario = entidad.IDModuloUsuario;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new ModuloUsuarioRepository();
            return repo.Delete(id);
        }

        public ModuloUsuarioDTO? Get(int id)
        {
            var repo = new ModuloUsuarioRepository();
            var entidad = repo.Get(id);

            if (entidad == null)
                return null;

            return new ModuloUsuarioDTO
            {
                IDModuloUsuario = entidad.IDModuloUsuario,
                IDModulo = entidad.IDModulo,
                IDUsuario = entidad.IDUsuario,
                Alta = entidad.Alta,
                Baja = entidad.Baja,
                Modificacion = entidad.Modificacion,
                Consulta = entidad.Consulta
            };
        }

        public IEnumerable<ModuloUsuarioDTO> GetAll()
        {
            var repo = new ModuloUsuarioRepository();
            return repo.GetAll().Select(e => new ModuloUsuarioDTO
            {
                IDModuloUsuario = e.IDModuloUsuario,
                IDModulo = e.IDModulo,
                IDUsuario = e.IDUsuario,
                Alta = e.Alta,
                Baja = e.Baja,
                Modificacion = e.Modificacion,
                Consulta = e.Consulta
            }).ToList();
        }

        public bool Update(ModuloUsuarioDTO dto)
        {
            var repo = new ModuloUsuarioRepository();
            var entidad = new ModuloUsuario(dto.IDModulo, dto.IDUsuario, dto.Alta, dto.Baja, dto.Modificacion, dto.Consulta);

            typeof(ModuloUsuario).GetProperty(nameof(ModuloUsuario.IDModuloUsuario))!
                                 .SetValue(entidad, dto.IDModuloUsuario);

            return repo.Update(entidad);
        }
    }
}
