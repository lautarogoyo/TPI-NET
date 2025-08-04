using WindowsForm;

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuraci�n de DPI y fuentes predeterminadas
            ApplicationConfiguration.Initialize();

            // Lanza el formulario principal de DocentesCurso
            Application.Run(new DocentesCursoLista());
        }
    }
}
