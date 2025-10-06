namespace Domain.Model
{
    public class Usuario
    {
        public int IDUsuario { get; private set; }
        public string NombreUsuario { get; private set; }
        public string Clave { get; private set; }
        public bool Habilitado { get; private set; }
        public bool CambiaClave { get; private set; }
        public int IDPersona { get; private set; }

        protected Usuario() { }

        public Usuario(string nombreUsuario, string clave, bool habilitado, bool cambiaClave, int idPersona)
        {
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Habilitado = habilitado;
            CambiaClave = cambiaClave;
            IDPersona = idPersona;
        }

        public void SetNombreUsuario(string nombreUsuario) => NombreUsuario = nombreUsuario;
        public void SetClave(string clave) => Clave = clave;
        public void SetHabilitado(bool habilitado) => Habilitado = habilitado;
        public void SetCambiaClave(bool cambia) => CambiaClave = cambia;
        public void SetIDPersona(int idPersona) => IDPersona = idPersona;
    }
}
