namespace DTOs
{
    public enum TiposCargos
    {
        Titular,
        Adjunto,
        JTP,
        Ayudante
    }

    public class DocenteCurso
    {
        public TiposCargos Cargo { get; set; }
        public int IDCurso { get; set; }
        public int IDDocente { get; set; }
    }
}