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
            );

            repo.Add(materia);

            dto.IDMateria = materia.IDMateria;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new MateriaRepository();
            var cmRepo = new ComisionMateriaRepository();
            if (cmRepo.ExisteRelacionConMateria(id))
            {
                throw new InvalidOperationException("No se puede eliminar la materia porque tiene comisiones asociadas.");
            }
            return repo.Delete(id);
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
                       })
                       .ToList();
        }

        public bool Update(MateriaDTO dto)
        {
            var repo = new MateriaRepository();
            var materia = repo.Get(dto.IDMateria);
            if (materia == null) return false;

            materia.SetDescripcion(dto.Descripcion);

            return repo.Update(materia);
        }
    }
}
