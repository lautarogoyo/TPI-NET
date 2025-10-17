namespace DTOs
{
    public class InscripcionDTO
    {
        public int IDInscripcion { get; set; }
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public int Condicion { get; set; }
        public int NotaFinal { get; set; }
        public string? NombreAlumno { get; set; }
        public string? ApellidoAlumno { get; set; }
        public string? DescCurso { get; set; }

    }
}
