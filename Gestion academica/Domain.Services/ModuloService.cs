using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ModuloService
    {
        public ModuloDTO Add(ModuloDTO dto)
        {
            var repo = new ModuloRepository();
            var modulo = new Modulo(dto.DescModulo, dto.Ejecuta);
            repo.Add(modulo);
            dto.IDModulo = modulo.IDModulo;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new ModuloRepository();
            return repo.Delete(id);
        }

        public ModuloDTO? Get(int id)
        {
            var repo = new ModuloRepository();
            var modulo = repo.Get(id);

            if (modulo == null)
                return null;

            return new ModuloDTO
            {
                IDModulo = modulo.IDModulo,
                DescModulo = modulo.DescModulo,
                Ejecuta = modulo.Ejecuta
            };
        }

        public IEnumerable<ModuloDTO> GetAll()
        {
            var repo = new ModuloRepository();
            return repo.GetAll().Select(m => new ModuloDTO
            {
                IDModulo = m.IDModulo,
                DescModulo = m.DescModulo,
                Ejecuta = m.Ejecuta
            }).ToList();
        }

        public bool Update(ModuloDTO dto)
        {
            var repo = new ModuloRepository();
            var modulo = new Modulo(dto.DescModulo, dto.Ejecuta);

            typeof(Modulo).GetProperty(nameof(Modulo.IDModulo))!
                          .SetValue(modulo, dto.IDModulo);

            return repo.Update(modulo);
        }
    }
}
