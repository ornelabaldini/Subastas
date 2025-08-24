using System;
using System.Windows.Forms;
using Subastas.Models;
using Subastas.Views;

namespace Subastas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var sistema = new SistemaSubastas();

            // Opcional: agregar datos de ejemplo
            sistema.CrearSubasta("Juan", "Guitarra", 1000m, 50m, DateTime.Now, 60);

            // Ejecutar el formulario interactivo
            Application.Run(new SubastaForm(sistema));
        }
    }
}
