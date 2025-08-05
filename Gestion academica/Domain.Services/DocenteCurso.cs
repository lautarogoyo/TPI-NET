using Data;
using Domain.Model;

namespace Domain.Services
{
    public class DocenteCursoService
    {
        public void Add(DocenteCurso docenteCurso)
        {
            DocenteCursoInMemory.DocentesCurso.Add(docenteCurso);
        }

        public bool Delete(int idDocente, int idCurso)
        {
            var item = DocenteCursoInMemory.DocentesCurso
                .FirstOrDefault(x => x.IDDocente == idDocente && x.IDCurso == idCurso);

            if (item != null)
            {
                DocenteCursoInMemory.DocentesCurso.Remove(item);
                return true;
            }

            return false;
        }

        public DocenteCurso? Get(int idDocente, int idCurso)
        {
            return DocenteCursoInMemory.DocentesCurso
                .FirstOrDefault(x => x.IDDocente == idDocente && x.IDCurso == idCurso);
        }

        public IEnumerable<DocenteCurso> GetAll()
        {
            return DocenteCursoInMemory.DocentesCurso.ToList();
        }

        public bool Update(DocenteCurso updated)
        {
            var current = DocenteCursoInMemory.DocentesCurso
                .FirstOrDefault(x => x.IDDocente == updated.IDDocente && x.IDCurso == updated.IDCurso);

            if (current != null)
            {
                current.SetCargo(updated.Cargo);
                return true;
            }

            return false;
        }
    }
}