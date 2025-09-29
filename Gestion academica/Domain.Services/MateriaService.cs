using System.Linq;
using Data;
using DTOs;
using Domain.Model;

namespace Application.Services
{
    public class MateriaService
    {
        public MateriaDTO Add(MateriaDTO dto)
        {
            var repo = new MateriaRepository();

            var materia = new Materia(
                dto.Descripcion
                //dto.HSSemanales,
                //dto.HSTotales,
                //dto.IDPlan
            );

            repo.Add(materia);

            dto.IDMateria = materia.IDMateria;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new MateriaRepository();
            return repo.Delete(id);
        }

        public MateriaDTO? Get(int id)
        {
            var repo = new MateriaRepository();
            var materia = repo.Get(id);
            if (materia == null) return null;

            return new MateriaDTO
            {
                IDMateria = materia.IDMateria,
                Descripcion = materia.Descripcion,
                /*
                HSSemanales = materia.HSSemanales,
                HSTotales = materia.HSTotales,
                IDPlan = materia.IDPlan
                */
            };
        }

        public IEnumerable<MateriaDTO> GetAll()
        {
            var repo = new MateriaRepository();
            return repo.GetAll()
                       .Select(m => new MateriaDTO
                       {
                           IDMateria = m.IDMateria,
                           Descripcion = m.Descripcion,
                           /*
                           HSSemanales = m.HSSemanales,
                           HSTotales = m.HSTotales,
                           IDPlan = m.IDPlan
                           */
                       })
                       .ToList();
        }

        public bool Update(MateriaDTO dto)
        {
            var repo = new MateriaRepository();
            var materia = repo.Get(dto.IDMateria);
            if (materia == null) return false;

            materia.SetDescripcion(dto.Descripcion);
            /*
            materia.SetHSSemanales(dto.HSSemanales);
            materia.SetHSTotales(dto.HSTotales);
            materia.SetIDPlan(dto.IDPlan);
            */

            return repo.Update(materia);
        }
    }
}
