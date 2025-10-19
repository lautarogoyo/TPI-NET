namespace DTOs

{
    public class PersonaDTO
    {
        public int IDPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateOnly FechaNac { get; set; }
        public string Legajo { get; set; }
        public int TipoPersona { get; set; } // 1=Alumno, 2=Docente
    }
}