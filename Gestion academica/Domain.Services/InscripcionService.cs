using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class InscripcionService
    {
        public InscripcionDTO Add(InscripcionDTO dto)
        {
            var repo = new InscripcionRepository();
            var inscripcion = new Inscripcion(dto.IDAlumno, dto.IDCurso, dto.Condicion, dto.NotaFinal);
            repo.Add(inscripcion);
            dto.IDInscripcion = inscripcion.IDInscripcion;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new InscripcionRepository();
            return repo.Delete(id);
        }

        public InscripcionDTO? Get(int id)
        {
            var repo = new InscripcionRepository();
            var entity = repo.Get(id);

            if (entity == null) return null;

            return new InscripcionDTO
            {
                IDInscripcion = entity.IDInscripcion,
                IDAlumno = entity.IDAlumno,
                IDCurso = entity.IDCurso,
                Condicion = entity.Condicion,
                NotaFinal = entity.NotaFinal
            };
        }

        public IEnumerable<InscripcionDTO> GetAll()
        {
            var repo = new InscripcionRepository();
            return repo.GetAll().Select(e => new InscripcionDTO
            {
                IDInscripcion = e.IDInscripcion,
                IDAlumno = e.IDAlumno,
                IDCurso = e.IDCurso,
                Condicion = e.Condicion,
                NotaFinal = e.NotaFinal
            }).ToList();
        }

        public bool Update(InscripcionDTO dto)
        {
            var repo = new InscripcionRepository();
            var i = repo.Get(dto.IDInscripcion);
            if (i == null) return false;

            i.SetIDAlumno(dto.IDAlumno);
            i.SetIDAlumno(dto.IDAlumno);
            i.SetCondicion(dto.Condicion);
            i.SetNotaFinal(dto.NotaFinal);

            return repo.Update(i);
        }
    }
}
