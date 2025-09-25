using System.Linq;
using Data;
using DTOs;
using Domain.Model;

namespace Application.Services
{
    public class ComisionService
    {
        public ComisionDTO Add(ComisionDTO dto)
        {
            var repo = new ComisionRepository();

            var comision = new Comision(
                dto.Descripcion,
                dto.AnioEspecialidad,
                dto.IDPlan
            );

            repo.Add(comision);

            dto.IDComision = comision.IDComision;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new ComisionRepository();
            return repo.Delete(id);
        }

        public ComisionDTO? Get(int id)
        {
            var repo = new ComisionRepository();
            var comision = repo.Get(id);
            if (comision == null) return null;

            return new ComisionDTO
            {
                IDComision = comision.IDComision,
                Descripcion = comision.Descripcion,
                AnioEspecialidad = comision.AnioEspecialidad,
                IDPlan = comision.IDPlan
            };
        }

        public IEnumerable<ComisionDTO> GetAll()
        {
            var repo = new ComisionRepository();
            return repo.GetAll()
                       .Select(c => new ComisionDTO
                       {
                           IDComision = c.IDComision,
                           Descripcion = c.Descripcion,
                           AnioEspecialidad = c.AnioEspecialidad,
                           IDPlan = c.IDPlan
                       })
                       .ToList();
        }

        public bool Update(ComisionDTO dto)
        {
            var repo = new ComisionRepository();
            var comision = repo.Get(dto.IDComision);
            if (comision == null) return false;

            comision.SetDescripcion(dto.Descripcion);
            comision.SetAnioEspecialidad(dto.AnioEspecialidad);
            comision.SetIDPlan(dto.IDPlan);

            return repo.Update(comision);
        }
    }
}
