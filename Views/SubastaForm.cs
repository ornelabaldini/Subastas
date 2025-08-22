using System;
using System.Windows.Forms;
using Subastas.Models;

namespace Subastas.Views
{
    public class SubastaForm : Form
    {
        private SistemaSubastas sistema;
        private ListBox listaSubastas;
        private Button btnActualizar;

        public SubastaForm(SistemaSubastas sistemaSubastas)
        {
            sistema = sistemaSubastas;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Sistema de Subastas";
            this.Width = 600;
            this.Height = 400;

            listaSubastas = new ListBox { Top = 20, Left = 20, Width = 540, Height = 280 };
            btnActualizar = new Button { Text = "Actualizar Subastas", Top = 310, Left = 20, Width = 200 };

            btnActualizar.Click += (sender, e) => ActualizarLista();

            this.Controls.Add(listaSubastas);
            this.Controls.Add(btnActualizar);

            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listaSubastas.Items.Clear();
            foreach (var subasta in sistema.SubastasActivas)
            {
                listaSubastas.Items.Add($"{subasta.Articulo} - Puja actual: {subasta.OfertaActual}");
            }
        }
    }
}

