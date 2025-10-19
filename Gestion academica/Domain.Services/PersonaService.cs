using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class PersonaService
    {
        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            var persona = new Persona(
                dto.Nombre,
                dto.Apellido,
                dto.Direccion,
                dto.Email,
                dto.TipoDoc,
                dto.NroDoc,
                dto.Telefono,
                dto.FechaNac,
                dto.Legajo,
                dto.TipoPersona
            );

            personaRepository.Add(persona);

            dto.IDPersona = persona.IDPersona;
            return dto;
        }

        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.Delete(id);
        }

        public PersonaDTO? Get(int id)
        {
            var personaRepository = new PersonaRepository();
            var persona = personaRepository.Get(id);

            if (persona == null)
                return null;

            return new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                TipoDoc = persona.TipoDoc,
                NroDoc = persona.NroDoc,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona
            };
        }

        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetAll().Select(persona => new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                TipoDoc = persona.TipoDoc,
                NroDoc = persona.NroDoc,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona
            }).ToList();
        }

        public IEnumerable<PersonaDTO> GetAllAlumnos()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetAllAlumnos().Select(persona => new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                TipoDoc = persona.TipoDoc,
                NroDoc = persona.NroDoc,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona
            }).ToList();
        }

        public IEnumerable<PersonaDTO> GetAllProfesores()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetAllProfesores().Select(persona => new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                TipoDoc = persona.TipoDoc,
                NroDoc = persona.NroDoc,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona
            }).ToList();
        }

        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            var persona = personaRepository.Get(dto.IDPersona);
            if (persona == null)
                return false;

            persona.SetNombre(dto.Nombre);
            persona.SetApellido(dto.Apellido);
            persona.SetDireccion(dto.Direccion);
            persona.SetEmail(dto.Email);
            persona.SetTipoDoc(dto.TipoDoc);
            persona.SetNroDoc(dto.NroDoc);
            persona.SetTelefono(dto.Telefono);
            persona.SetFechaNac(dto.FechaNac);
            persona.SetLegajo(dto.Legajo);
            persona.SetTipoPersona(dto.TipoPersona);

            return personaRepository.Update(persona);
        }

        public IEnumerable<PersonaDTO> GetPersonasSinUsuario()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetPersonasSinUsuario().Select(persona => new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                TipoDoc = persona.TipoDoc,
                NroDoc = persona.NroDoc,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona
            }).ToList();
        }
    }
}
