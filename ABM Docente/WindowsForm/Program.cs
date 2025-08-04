using WindowsForm;

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración de DPI y fuentes predeterminadas
            ApplicationConfiguration.Initialize();

            // Lanza el formulario principal de DocentesCurso
            Application.Run(new DocentesCursoLista());
        }
    }
}
