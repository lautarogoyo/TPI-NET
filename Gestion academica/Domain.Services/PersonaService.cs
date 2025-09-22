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
                dto.Telefono,
                dto.FechaNac,
                dto.Legajo,
                dto.TipoPersona,
                dto.IDPlan
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
            Persona? persona = personaRepository.Get(id);

            if (persona == null)
                return null;

            return new PersonaDTO
            {
                IDPersona = persona.IDPersona,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IDPlan = persona.IDPlan
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
                Email = persona.Email,
                Telefono = persona.Telefono,
                FechaNac = persona.FechaNac,
                Legajo = persona.Legajo,
                TipoPersona = persona.TipoPersona,
                IDPlan = persona.IDPlan
            }).ToList();
        }

        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            var persona = new Persona(
                dto.Nombre,
                dto.Apellido,
                dto.Direccion,
                dto.Email,
                dto.Telefono,
                dto.FechaNac,
                dto.Legajo,
                dto.TipoPersona,
                dto.IDPlan
            );

            // Necesitamos setear el ID porque el constructor no lo recibe
            typeof(Persona)
                .GetProperty(nameof(Persona.IDPersona))!
                .SetValue(persona, dto.IDPersona);

            return personaRepository.Update(persona);
        }
    }
}
