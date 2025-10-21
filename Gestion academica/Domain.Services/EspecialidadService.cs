using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class EspecialidadService
    {
        // === Crear nueva Especialidad ===
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");

            var especialidadRepository = new EspecialidadRepository();

            // Crear entidad de dominio
            var especialidad = new Especialidad(dto.Descripcion.Trim());

            // Guardar en base (ADO.NET)
            int nuevoId = especialidadRepository.Add(especialidad);

            // Actualizar DTO con el nuevo ID
            dto.IDEspecialidad = nuevoId;

            return dto;
        }

        // === Eliminar una Especialidad ===
        public bool Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            var planRepo = new PlanRepository();

            if (planRepo.ExistePlanConEspecialidad(id))
                throw new InvalidOperationException("No se puede eliminar la especialidad porque tiene planes asociados.");

            return especialidadRepository.Delete(id);
        }

        // === Obtener una Especialidad por ID ===
        public EspecialidadDTO? Get(int id)
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

        // === Obtener todas las Especialidades ===
        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();

            return especialidadRepository.GetAll()
                .Select(e => new EspecialidadDTO
                {
                    IDEspecialidad = e.IDEspecialidad,
                    Descripcion = e.Descripcion
                })
                .ToList();
        }

        // === Actualizar una Especialidad ===
        public bool Update(EspecialidadDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.IDEspecialidad <= 0) return false;

            var repo = new EspecialidadRepository();
            var ent = repo.Get(dto.IDEspecialidad);

            if (ent == null) return false;

            ent.SetDescripcion(dto.Descripcion?.Trim() ?? string.Empty);
            return repo.Update(ent);
        }
    }
}
