using System;
using System.Windows.Forms;
using Subastas.Models;
using Subastas.Views;

namespace Subastas.Controllers
{
    public class SubastaController
    {
        private SistemaSubastas sistema;

        public SubastaController(SistemaSubastas sistemaSubastas)
        {
            sistema = sistemaSubastas;
        }

        public void CrearSubasta(string nombreSubastador, string articulo, decimal pujaInicial, decimal incremento, DateTime fecha, int duracion)
        {
            sistema.CrearSubasta(nombreSubastador, articulo, pujaInicial, incremento, fecha, duracion);
        }

        public void MostrarFormularioSubasta()
        {
            var form = new SubastaForm(sistema);
            Application.Run(form);
        }
    }
}

