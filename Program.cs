using System;
using System.Windows.Forms;
using Subastas.Controllers;
using Subastas.Views;

namespace Subastas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Creamos la vista
            var form = new SubastaForm();

            // Creamos el controlador y lo conectamos con la vista
            var controller = new SubastaController(form);

            // Ejecutamos la aplicación
            Application.Run(form);
        }
    }
}

