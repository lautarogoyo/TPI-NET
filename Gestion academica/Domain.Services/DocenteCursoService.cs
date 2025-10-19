using System.Linq;
using Data;


using DocenteCursoDto = DTOs.DocenteCurso;
using CargoDto = DTOs.TiposCargos;
using DocenteCursoEntity = Domain.Model.DocenteCurso;
using CargoEntity = Domain.Model.TiposCargos;

namespace Application.Services
{
    public class DocenteCursoService
    {
        public DocenteCursoDto Add(DocenteCursoDto dto)
        {
            var repo = new DocenteCursoRepository();

            
            var entidad = new DocenteCursoEntity(
                (CargoEntity)dto.Cargo,
                dto.IDCurso,
                dto.IDDocente
            );

            repo.Add(entidad);
            return dto; 
        }

        public bool Delete(int idCurso, int idDocente)
        {
            var repo = new DocenteCursoRepository();
            return repo.Delete(idCurso, idDocente);
        }

        public DocenteCursoDto? Get(int idCurso, int idDocente)
        {
            var repo = new DocenteCursoRepository();
            var dc = repo.Get(idCurso, idDocente);
            if (dc == null) return null;

            
            return new DocenteCursoDto
            {
                Cargo = (CargoDto)dc.Cargo,
                IDCurso = dc.IDCurso,
                IDDocente = dc.IDDocente
            };
        }

        public IEnumerable<DocenteCursoDto> GetAll()
        {
            var repo = new DocenteCursoRepository();
            return repo.GetAll()
                       .Select(dc => new DocenteCursoDto
                       {
                           Cargo = (CargoDto)dc.Cargo, 
                           IDCurso = dc.IDCurso,
                           IDDocente = dc.IDDocente
                       })
                       .ToList();
        }

        public bool Update(DocenteCursoDto dto)
        {
            var repo = new DocenteCursoRepository();

            
            var entidad = new DocenteCursoEntity(
                (CargoEntity)dto.Cargo, 
                dto.IDCurso,
                dto.IDDocente
            );

            return repo.Update(entidad);
        }
    }
}
