namespace DTOs
{
    public enum TiposCargos
    {
        Titular,
        Adjunto,
        JTP,
        Ayudante
    }

    public class DocenteCursoDTO
    {
        public int IdDocenteCurso { get; set; }
        public TiposCargos Cargo { get; set; }
        public int IDCurso { get; set; }
        public int IDDocente { get; set; }
        public string? NombreDocente { get; set; }
        public string? DescCurso { get; set; }
        public string? DescMateria { get; set; }
        public string? DescComision { get; set; }
        public int? Anio { get; set; }
    }
}