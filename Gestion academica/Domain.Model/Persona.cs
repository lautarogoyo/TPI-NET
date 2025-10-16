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
        public string TipoDoc { get; private set; }
        public string NroDoc { get; private set; }
        public string Telefono { get; private set; }
        public DateOnly FechaNac { get; private set; }
        public string Legajo { get; private set; }
        public int TipoPersona { get; private set; }
       
        //public ICollection<AlumnoInscripcion> AlumnoInscripciones = new List<AlumnoInscripcion>();

        // Constructor para EF
        protected Persona() { }

        // Constructor para crear una nueva Persona
        public Persona(string nombre, string apellido, string direccion, string email, string tipoDoc, string nroDoc, string telefono,
                       DateOnly fechaNac, string legajo, int tipoPersona)
        {
            SetNombre(nombre); 
            SetApellido(apellido); 
            SetDireccion(direccion); 
            SetEmail(email); 
            SetTipoDoc(tipoDoc);
            SetNroDoc(nroDoc);
            SetTelefono(telefono);
            SetFechaNac(fechaNac);
            SetLegajo(legajo);
            SetTipoPersona(tipoPersona);
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede estar vacía.", nameof(direccion));
            Direccion = direccion;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacía.", nameof(email));
            Email = email;
        }
        public void SetTipoDoc(string tipoDoc)
        {
            if (string.IsNullOrWhiteSpace(tipoDoc))
                throw new ArgumentException("El tipo de documento no puede estar vacía.", nameof(tipoDoc));
            TipoDoc = tipoDoc;
        }
        public void SetNroDoc(string nroDoc)
        {
            if (string.IsNullOrWhiteSpace(nroDoc))
                throw new ArgumentException("El número de documento no puede estar vacía.", nameof(nroDoc));
            NroDoc = nroDoc;
        }
        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El tipo de documento no puede estar vacía.", nameof(telefono));
            Telefono = telefono;
        }
        public void SetFechaNac(DateOnly fechaNac) => FechaNac = fechaNac;
        public void SetLegajo(string legajo)
        {
            if (string.IsNullOrWhiteSpace(legajo))
                throw new ArgumentException("El tipo de documento no puede estar vacía.", nameof(legajo));
            Legajo = legajo;
        }
        public void SetTipoPersona(int tipoPersona)
        {
            if (tipoPersona!=1 && tipoPersona!=2)
                throw new ArgumentException("El tipo de persona debe ser correcto.", nameof(tipoPersona));
            TipoPersona = tipoPersona;
        }
    }
}
