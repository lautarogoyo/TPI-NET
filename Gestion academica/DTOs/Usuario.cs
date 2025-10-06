namespace DTOs
{
    public class UsuarioDTO
    {
        public int IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public bool CambiaClave { get; set; }
        public int IDPersona { get; set; }
    }
}
