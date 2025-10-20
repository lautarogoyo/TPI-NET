namespace DTOs
{
    public class InscripcionDTO
    {
        public int IDInscripcion { get; set; }
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public string Condicion { get; set; }
        public int NotaFinal { get; set; }
        public string? DescCurso { get; set; }
        public string? DescMateria { get; set; }
        public string? DescComision { get; set; }
        public int? Anio { get; set; }
        public PersonaDTO? Alumno { get; set; }
    }
}
