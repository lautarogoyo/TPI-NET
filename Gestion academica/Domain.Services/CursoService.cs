using System.Linq;
using Data;
using DTOs;

namespace Application.Services
{
    public class CursoService
    {
        public CursoDTO Add(CursoDTO dto)
        {
            var repo = new CursoRepository();

            var curso = new Domain.Model.Curso(
                dto.AnioCalendario,
                dto.Cupo,
                dto.Descripcion,
                dto.IDComision,
                dto.IDMateria
            );

            repo.Add(curso);

            // devolver con Id asignado por EF
            dto.IdCurso = curso.IdCurso;
            return dto;
        }

        public bool Delete(int idCurso)
        {
            var repo = new CursoRepository();
            return repo.Delete(idCurso);
        }

        public CursoDTO? Get(int idCurso)
        {
            var repo = new CursoRepository();
            var curso = repo.Get(idCurso);
            if (curso == null) return null;

            return new CursoDTO
            {
                IdCurso = curso.IdCurso,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                Descripcion = curso.Descripcion,
                IDComision = curso.IDComision,
                IDMateria = curso.IDMateria
            };
        }

        public IEnumerable<CursoDTO> GetAll()
        {
            var repo = new CursoRepository();
            return repo.GetAll()
                       .Select(c => new CursoDTO
                       {
                           IdCurso = c.IdCurso,
                           AnioCalendario = c.AnioCalendario,
                           Cupo = c.Cupo,
                           Descripcion = c.Descripcion,
                           IDComision = c.IDComision,
                           IDMateria = c.IDMateria
                       })
                       .ToList();
        }

        public bool Update(CursoDTO dto)
        {
            var repo = new CursoRepository();

            // Recuperamos el existente para mantener el IdCurso
            var curso = repo.Get(dto.IdCurso);
            if (curso == null) return false;

            curso.SetAnio(dto.AnioCalendario);
            curso.SetCupo(dto.Cupo);
            curso.SetDescripcion(dto.Descripcion);
            curso.SetIDComision(dto.IDComision);
            curso.SetIDMateria(dto.IDMateria);

            return repo.Update(curso);
        }
    }
}
