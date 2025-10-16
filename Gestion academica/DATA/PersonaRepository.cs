using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas.Find(id);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas.ToList();
        }

        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.IDPersona);
            if (existingPersona != null)
            {
                existingPersona.SetNombre(persona.Nombre);
                existingPersona.SetApellido(persona.Apellido);
                existingPersona.SetDireccion(persona.Direccion);
                existingPersona.SetEmail(persona.Email);
                existingPersona.SetTipoDoc(persona.TipoDoc);
                existingPersona.SetNroDoc(persona.NroDoc);
                existingPersona.SetTelefono(persona.Telefono);
                existingPersona.SetFechaNac(persona.FechaNac);
                existingPersona.SetLegajo(persona.Legajo);
                existingPersona.SetTipoPersona(persona.TipoPersona);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
