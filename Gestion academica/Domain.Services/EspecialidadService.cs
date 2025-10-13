using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class EspecialidadService
    {
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            var especialidad = new Especialidad(dto.Descripcion);

            especialidadRepository.Add(especialidad);

            dto.IDEspecialidad = especialidad.IDEspecialidad;

            return dto;
        }


        public bool Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.Delete(id);
        }
        public EspecialidadDTO Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = especialidadRepository.Get(id);

            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                IDEspecialidad = especialidad.IDEspecialidad,
                Descripcion = especialidad.Descripcion
            };
        }

        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.GetAll().Select(especialidad => new EspecialidadDTO
            {
                IDEspecialidad = especialidad.IDEspecialidad,
                Descripcion = especialidad.Descripcion
            }).ToList();
        }
        public bool Update(EspecialidadDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.IDEspecialidad <= 0) return false;

            var repo = new EspecialidadRepository();

            var ent = repo.Get(dto.IDEspecialidad);
            if (ent == null) return false;

            ent.SetDescripcion(dto.Descripcion?.Trim());
            return repo.Update(ent);
        }

    }
}
