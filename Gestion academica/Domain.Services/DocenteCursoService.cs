using System.Linq;
using Data;


using DTOs;
using CargoDto = DTOs.TiposCargos;
using DocenteCursoEntity = Domain.Model.DocenteCurso;
using CargoEntity = Domain.Model.TiposCargos;

namespace Application.Services
{
    public class DocenteCursoService
    {
        public DocenteCursoDTO Add(DocenteCursoDTO dto)
        {
            var repo = new DocenteCursoRepository();

            
            var entidad = new DocenteCursoEntity(
                (CargoEntity)dto.Cargo,
                dto.IDCurso,
                dto.IDDocente
            );

            repo.Add(entidad);
            dto.IdDocenteCurso = entidad.IdDocenteCurso;
            return dto; 
        }

        public bool Delete(int idDocenteCurso)
        {
            var repo = new DocenteCursoRepository();
            return repo.Delete(idDocenteCurso);
        }

        public DocenteCursoDTO? Get(int idDocenteCurso)
        {
            var repo = new DocenteCursoRepository();
            var dc = repo.Get(idDocenteCurso);
            if (dc == null) return null;

            
            return new DocenteCursoDTO
            {

                Cargo = (CargoDto)dc.Cargo,
                IDCurso = dc.IDCurso,
                IDDocente = dc.IDDocente
            };
        }

        public IEnumerable<DocenteCursoDTO> GetAll()
        {
            var repo = new DocenteCursoRepository();
            return repo.GetAll()
                       .Select(dc => new DocenteCursoDTO
                       {
                           IdDocenteCurso = dc.IdDocenteCurso,
                           Cargo = (CargoDto)dc.Cargo, 
                           IDCurso = dc.IDCurso,
                           IDDocente = dc.IDDocente,
                           NombreDocente = dc.Docente != null ? $"{dc.Docente.Nombre} {dc.Docente.Apellido}" : null,
                           DescCurso = dc.Curso != null ? dc.Curso.Descripcion : null
                       })
                       .ToList();
        }

        public bool Update(DocenteCursoDTO dto)
        {
            var repo = new DocenteCursoRepository();
            var dc = repo.Get(dto.IdDocenteCurso);
            if (dc == null) return false;

            dc.SetCargo((CargoEntity)dto.Cargo);
            dc.SetIDCurso(dto.IDCurso);
            dc.SetIDDocente(dto.IDDocente);

            return repo.Update(dc);
        }
    }
}
