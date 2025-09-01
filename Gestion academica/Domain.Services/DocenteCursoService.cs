using System.Linq;
using Data;

// Alias para evitar ambigüedades y castear fácil
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

            // Cast explícito de enum DTO -> Entity
            var entidad = new DocenteCursoEntity(
                (CargoEntity)dto.Cargo,
                dto.IDCurso,
                dto.IDDocente
            );

            repo.Add(entidad);
            return dto; // PK compuesta, no devolvemos Id
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

            // Cast explícito de enum Entity -> DTO
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
                           Cargo = (CargoDto)dc.Cargo, // Entity -> DTO
                           IDCurso = dc.IDCurso,
                           IDDocente = dc.IDDocente
                       })
                       .ToList();
        }

        public bool Update(DocenteCursoDto dto)
        {
            var repo = new DocenteCursoRepository();

            // Update por PK compuesta. Solo cambia el Cargo.
            var entidad = new DocenteCursoEntity(
                (CargoEntity)dto.Cargo, // DTO -> Entity
                dto.IDCurso,
                dto.IDDocente
            );

            return repo.Update(entidad);
        }
    }
}
