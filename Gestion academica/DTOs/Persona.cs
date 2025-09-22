namespace DTOs

{ 
public class PersonaDTO
{
    public int IDPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaNac { get; set; }
    public int Legajo { get; set; }
    public string TipoPersona { get; set; }
    public int IDPlan { get; set; } // <<--- clave foránea
}
}