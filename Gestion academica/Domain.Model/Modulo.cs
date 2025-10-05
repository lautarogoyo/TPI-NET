namespace Domain.Model
{
    public class Modulo
    {
        public int IDModulo { get; private set; }
        public string DescModulo { get; private set; }
        public string Ejecuta { get; private set; }

        protected Modulo() { }

        public Modulo(string descModulo, string ejecuta)
        {
            DescModulo = descModulo;
            Ejecuta = ejecuta;
        }

        public void SetDescripcion(string desc) => DescModulo = desc;
        public void SetEjecuta(string ejecuta) => Ejecuta = ejecuta;
    }
}
