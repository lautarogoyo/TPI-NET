using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ComisionMateriaService
    {
        public ComisionMateriaDTO Add(ComisionMateriaDTO dto)
        {
            var repo = new ComisionMateriaRepository();

            var comisionMateria = new ComisionMateria(dto.HsSemanales, dto.HsTotales, dto.IDComision, dto.IDMateria);
            repo.Add(comisionMateria);

            dto.IDComisionMateria = comisionMateria.IDComisionMateria;
            return dto;
        }

        public bool Delete(int id)
        {
            var cmRepository = new ComisionMateriaRepository();
            return cmRepository.Delete(id);
        }

        public ComisionMateriaDTO? Get(int id)
        {
            var repo = new ComisionMateriaRepository();
            var comisionMateria = repo.Get(id);

            if (comisionMateria == null)
                return null;

            return new ComisionMateriaDTO
            {
                IDComisionMateria = comisionMateria.IDComisionMateria,
                HsSemanales = comisionMateria.HsSemanales,
                HsTotales = comisionMateria.HsTotales,
                IDComision = comisionMateria.IDComision,
                IDMateria = comisionMateria.IDMateria
            };
        }

        public IEnumerable<ComisionMateriaDTO> GetAll()
        {
            var repo = new ComisionMateriaRepository();
            return repo.GetAll().Select(cm => new ComisionMateriaDTO
            {
                IDComisionMateria = cm.IDComisionMateria,
                HsSemanales = cm.HsSemanales,
                HsTotales = cm.HsTotales,
                IDComision = cm.IDComision,
                IDMateria = cm.IDMateria
            }).ToList();
        }

        public bool Update(ComisionMateriaDTO dto)
        {
            var repo = new ComisionMateriaRepository();
            var cm = repo.Get(dto.IDComisionMateria);
            if (cm == null) return false;

            cm.SetHsSemanales(dto.HsSemanales);
            cm.SetHsTotales(dto.HsTotales);
            cm.SetIDComision(dto.IDComision);
            cm.SetIDMateria(dto.IDMateria);

            return repo.Update(cm);
        }
    }
}