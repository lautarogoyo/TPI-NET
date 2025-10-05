using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class AlumnoInscripcionService
    {
        public AlumnoInscripcionDTO Add(AlumnoInscripcionDTO dto)
        {
            var repo = new AlumnoInscripcionRepository();
            var inscripcion = new AlumnoInscripcion(dto.IDAlumno, dto.IDCurso, dto.Condicion, dto.Nota);
            repo.Add(inscripcion);
            dto.IDInscripcion = inscripcion.IDInscripcion;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new AlumnoInscripcionRepository();
            return repo.Delete(id);
        }

        public AlumnoInscripcionDTO? Get(int id)
        {
            var repo = new AlumnoInscripcionRepository();
            var entity = repo.Get(id);

            if (entity == null) return null;

            return new AlumnoInscripcionDTO
            {
                IDInscripcion = entity.IDInscripcion,
                IDAlumno = entity.IDAlumno,
                IDCurso = entity.IDCurso,
                Condicion = entity.Condicion,
                Nota = entity.Nota
            };
        }

        public IEnumerable<AlumnoInscripcionDTO> GetAll()
        {
            var repo = new AlumnoInscripcionRepository();
            return repo.GetAll().Select(e => new AlumnoInscripcionDTO
            {
                IDInscripcion = e.IDInscripcion,
                IDAlumno = e.IDAlumno,
                IDCurso = e.IDCurso,
                Condicion = e.Condicion,
                Nota = e.Nota
            }).ToList();
        }

        public bool Update(AlumnoInscripcionDTO dto)
        {
            var repo = new AlumnoInscripcionRepository();
            var inscripcion = new AlumnoInscripcion(dto.IDAlumno, dto.IDCurso, dto.Condicion, dto.Nota);
            typeof(AlumnoInscripcion).GetProperty(nameof(AlumnoInscripcion.IDInscripcion))!
                                      .SetValue(inscripcion, dto.IDInscripcion);
            return repo.Update(inscripcion);
        }
    }
}
