using System;
using System.Windows.Forms;
using Subastas.Controllers;
using Subastas.Models;

namespace Subastas
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var sistema = new SistemaSubastas();
            var controlador = new SubastaController(sistema);

            // Crear ejemplo de subasta
            controlador.CrearSubasta("Juan", "Guitarra", 1000m, 50m, DateTime.Now, 60);

            controlador.MostrarFormularioSubasta();
        }
    }
}

