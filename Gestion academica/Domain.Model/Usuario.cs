namespace Domain.Model
{
    public class Usuario
    {
        public int IDUsuario { get; private set; }
        public string NombreUsuario { get; private set; }
        public string Clave { get; private set; }
        public bool Habilitado { get; private set; }
        public int IDPersona { get; private set; }
        public Persona Persona { get; private set; }// navegación

        protected Usuario() { }

        public Usuario(string nombreUsuario, string clave, bool habilitado, int idPersona)
        {
            SetNombreUsuario(nombreUsuario);
            SetClave(clave);
            SetHabilitado(habilitado);
            SetIDPersona(idPersona);
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }
        public void SetClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La clave no puede estar vacía.", nameof(clave));
            Clave = clave;
        }
        public void SetHabilitado(bool habilitado)
        {
            Habilitado = habilitado;
        }
        public void SetIDPersona(int idPersona)
        {
            if (idPersona <= 0) throw new ArgumentException("El ID de la persona debe ser mayor que 0.", nameof(idPersona));
            IDPersona = idPersona;
        }
    }
}
