namespace DTOs
{
    public class UsuarioDTO
    {
        public int IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public int IDPersona { get; set; }
        public string? NombreApellidoPersona { get; set; }
        public string? Legajo { get; set; }
        public int? TipoPersona { get; set; }

    }
}
