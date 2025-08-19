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

            Especialidad especialidad = new Especialidad(0, dto.Descripcion);

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
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(dto.IDEspecialidad, dto.Descripcion);
            return especialidadRepository.Update(especialidad);
        }
    }
}
