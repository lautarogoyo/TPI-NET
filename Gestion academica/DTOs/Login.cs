using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public sealed class LoginRequestDTO
    {
        public string Usuario { get; set; } = "";
        public string Clave { get; set; } = "";
    }

    public sealed class LoginResponseDTO
    {
        public string Token { get; set; } = "";
        public string UserName { get; set; } = "";
        public int PersonaId { get; set; }
        public int TipoPersona { get; set; }  // 1/2
        public string Role { get; set; } = ""; // "Alumno" / "Profesor"
    }

}
