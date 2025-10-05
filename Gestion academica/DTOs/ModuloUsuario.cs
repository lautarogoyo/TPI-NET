namespace DTOs
{
    public class ModuloUsuarioDTO
    {
        public int IDModuloUsuario { get; set; }
        public int IDModulo { get; set; }
        public int IDUsuario { get; set; }
        public bool Alta { get; set; }
        public bool Baja { get; set; }
        public bool Modificacion { get; set; }
        public bool Consulta { get; set; }
    }
}
