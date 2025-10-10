using System;

namespace Domain.Model
{
    public class Persona
    {
        public int IDPersona { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public DateTime FechaNac { get; private set; }
        public int Legajo { get; private set; }
        public string TipoPersona { get; private set; }
        public int IDPlan { get; private set; }
        public Plan Plan { get; private set; } // navegación
        public ICollection<AlumnoInscripcion> AlumnoInscripciones = new List<AlumnoInscripcion>();

        // Constructor para EF
        protected Persona() { }

        // Constructor para crear una nueva Persona
        public Persona(string nombre, string apellido, string direccion, string email, string telefono,
                       DateTime fechaNac, int legajo, string tipoPersona, int idPlan)
        {
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            FechaNac = fechaNac;
            Legajo = legajo;
            TipoPersona = tipoPersona;
            IDPlan = idPlan;
        }

        // Métodos para actualizar campos
        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetApellido(string apellido) => Apellido = apellido;
        public void SetDireccion(string direccion) => Direccion = direccion;
        public void SetEmail(string email) => Email = email;
        public void SetTelefono(string telefono) => Telefono = telefono;
        public void SetFechaNac(DateTime fechaNac) => FechaNac = fechaNac;
        public void SetLegajo(int legajo) => Legajo = legajo;
        public void SetTipoPersona(string tipoPersona) => TipoPersona = tipoPersona;
        public void SetIDPlan(int idPlan) => IDPlan = idPlan;
    }
}
