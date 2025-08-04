using System.Text.RegularExpressions;
namespace Domain.Model
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
        public TiposCargos Cargo { get; private set; }
        public int IDCurso { get; private set; }
        public int IDDocente { get; private set; }

        public DocenteCurso(TiposCargos cargo, int idCurso, int idDocente)
        {
            SetCargo(cargo);
            SetIDCurso(idCurso);
            SetIDDocente(idDocente);
        }

        public void SetCargo(TiposCargos cargo)
        {
            Cargo = cargo;
        }

        public void SetIDCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID del curso debe ser mayor que 0.", nameof(idCurso));
            IDCurso = idCurso;
        }

        public void SetIDDocente(int idDocente)
        {
            if (idDocente <= 0)
                throw new ArgumentException("El ID del docente debe ser mayor que 0.", nameof(idDocente));
            IDDocente = idDocente;
        }
    }
}