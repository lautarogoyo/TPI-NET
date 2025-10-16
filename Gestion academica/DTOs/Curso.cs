namespace DTOs
{
    public class CursoDTO
    {
        public int IdCurso { get; set; } 
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public string Descripcion { get; set; }
        public int IDComisionMateria { get; set; }
        public int? IDComision { get; set; }
        public int? IDMateria { get; set; }
        public string? DescMateria { get; set; }
        public string? DescComision { get; set; }
        public int? HsSemanales { get; set; }
        public int? HsTotales { get; set; }
    }
}
