namespace Domain.Model
{
    public class ModuloUsuario
    {
        public int IDModuloUsuario { get; private set; }
        public int IDModulo { get; private set; }
        public int IDUsuario { get; private set; }

        public bool Alta { get; private set; }
        public bool Baja { get; private set; }
        public bool Modificacion { get; private set; }
        public bool Consulta { get; private set; }

        protected ModuloUsuario() { }

        public ModuloUsuario(int idModulo, int idUsuario, bool alta, bool baja, bool modificacion, bool consulta)
        {
            IDModulo = idModulo;
            IDUsuario = idUsuario;
            Alta = alta;
            Baja = baja;
            Modificacion = modificacion;
            Consulta = consulta;
        }

        public void SetPermisos(bool alta, bool baja, bool modificacion, bool consulta)
        {
            Alta = alta;
            Baja = baja;
            Modificacion = modificacion;
            Consulta = consulta;
        }

        public void SetIDModulo(int idModulo) => IDModulo = idModulo;
        public void SetIDUsuario(int idUsuario) => IDUsuario = idUsuario;
    }
}
