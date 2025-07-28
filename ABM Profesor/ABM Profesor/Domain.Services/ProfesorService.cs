using Domain.Model;
using DATA;

namespace Domain.Services
{
    public class ProfesorService
    {
        public void Add(Profesor profesor)
        {
            profesor.SetId(GetNextId());
            ProfesorInMemory.Profesores.Add(profesor);
        }
        public bool Delete(int id)
        {
            Profesor? profesorToDelete = ProfesorInMemory.Profesores.Find(x => x.Id == id);
            if (profesorToDelete != null)
            {
                ProfesorInMemory.Profesores.Remove(profesorToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Profesor Get(int id)
        {
            //Deberia devolver un objeto cloneado 
            return ProfesorInMemory.Profesores.Find(x => x.Id == id);
        }
        public IEnumerable<Profesor> GetAll()
        {
            //Devuelvo una lista nueva cada vez que se llama a GetAll
            //pero idealmente deberia implementar un Deep Clone
            return ProfesorInMemory.Profesores.ToList();
        }
        public bool Update(Profesor profesor)
        {
            Profesor? profesorToUpdate = ProfesorInMemory.Profesores.Find(x => x.Id == profesor.Id);
            if (profesorToUpdate != null)
            {
                profesorToUpdate.SetNombre(profesor.Nombre);
                profesorToUpdate.SetApellido(profesor.Apellido);
                profesorToUpdate.SetEmail(profesor.Email);
                profesorToUpdate.SetMateria(profesor.Materia);
                return true;
            }
            else
            {
                return false;
            }
        }
        //No es ThreadSafe pero sirve para el proposito del ejemplo        
        private static int GetNextId()
        {
            int nextId;
            if (ProfesorInMemory.Profesores.Count > 0)
            {
                nextId = ProfesorInMemory.Profesores.Max(x => x.Id) + 1;
            }
            else
            {
                nextId = 1;
            }
            return nextId;
        }
    }
}
   