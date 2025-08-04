using Domain.Model;
using DATA;

namespace Domain.Services
{
    public class EspecialidadServices
    {
        public void Add(Especialidad especialidad)
        {
            especialidad.SetID(GetNextId());

            EspecialidadInMemory.Especialidades.Add(especialidad);
        }

        public bool Delete(int id)
        {
            Especialidad? especialidadToDelete = EspecialidadInMemory.Especialidades.Find(x => x.IDEspecialidad == id);

            if (especialidadToDelete != null)
            {
                EspecialidadInMemory.Especialidades.Remove(especialidadToDelete);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Especialidad Get(int id)
        {
       
            return EspecialidadInMemory.Especialidades.Find(x => x.IDEspecialidad == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
          
            return EspecialidadInMemory.Especialidades.ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            Especialidad? especialidadToUpdate = EspecialidadInMemory.Especialidades.Find(x => x.IDEspecialidad == especialidad.IDEspecialidad);

            if (especialidadToUpdate != null)
            {
                especialidadToUpdate.SetDescripcion(especialidad.Descripcion);

                return true;
            }
            else
            {
                return false;
            }
        }   
        private static int GetNextId()
        {
            int nextId;

            if (EspecialidadInMemory.Especialidades.Count > 0)
            {
                nextId = EspecialidadInMemory.Especialidades.Max(x => x.IDEspecialidad) + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }
    }
}