using System;
using System.Drawing;
using System.Windows.Forms;
using Subastas.Models;

namespace Subastas.Views
{
    public class SubastaForm : Form
    {
        private SistemaSubastas sistema;

        // Controles
        private ListView listaSubastas;
        private Button btnActualizar;
        private TextBox txtArticulo, txtSubastador, txtPujaInicial, txtIncremento, txtDuracion;
        private TextBox txtNombrePostor, txtNumeroPostor, txtOferta;
        private Button btnCrearSubasta, btnCrearPostor, btnHacerOferta;

        public SubastaForm(SistemaSubastas sistemaSubastas)
        {
            sistema = sistemaSubastas;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Configuración general del formulario
            this.Text = "Sistema de Subastas";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(34, 34, 34);
            this.Font = new Font("Segoe UI", 10);

            // Lista de subastas
            listaSubastas = new ListView
            {
                Top = 20,
                Left = 20,
                Width = 500,
                Height = 250,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };
            listaSubastas.Columns.Add("Artículo", 250);
            listaSubastas.Columns.Add("Puja actual", 200);

            // Botón actualizar
            btnActualizar = new Button
            {
                Text = "Actualizar Lista",
                Top = 280,
                Left = 20,
                Width = 200,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnActualizar.Click += (s, e) => ActualizarLista();

            // Crear subasta
            txtSubastador = new TextBox { Top = 320, Left = 20, Width = 120, PlaceholderText = "Subastador" };
            txtArticulo = new TextBox { Top = 320, Left = 150, Width = 120, PlaceholderText = "Artículo" };
            txtPujaInicial = new TextBox { Top = 320, Left = 280, Width = 80, PlaceholderText = "Puja inicial" };
            txtIncremento = new TextBox { Top = 320, Left = 370, Width = 80, PlaceholderText = "Incremento" };
            txtDuracion = new TextBox { Top = 320, Left = 460, Width = 80, PlaceholderText = "Duración(min)" };

            btnCrearSubasta = new Button
            {
                Text = "Crear Subasta",
                Top = 350,
                Left = 20,
                Width = 200,
                BackColor = Color.FromArgb(0, 150, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCrearSubasta.Click += BtnCrearSubasta_Click;

            // Crear postor
            txtNumeroPostor = new TextBox { Top = 400, Left = 20, Width = 80, PlaceholderText = "Nro" };
            txtNombrePostor = new TextBox { Top = 400, Left = 110, Width = 150, PlaceholderText = "Nombre" };
            btnCrearPostor = new Button
            {
                Text = "Crear Postor",
                Top = 430,
                Left = 20,
                Width = 150,
                BackColor = Color.FromArgb(0, 150, 150),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCrearPostor.Click += BtnCrearPostor_Click;

            // Hacer oferta
            txtOferta = new TextBox { Top = 480, Left = 20, Width = 100, PlaceholderText = "Monto oferta" };
            btnHacerOferta = new Button
            {
                Text = "Hacer Oferta",
                Top = 480,
                Left = 130,
                Width = 150,
                BackColor = Color.FromArgb(150, 0, 150),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnHacerOferta.Click += BtnHacerOferta_Click;

            // Agregar controles al formulario
            this.Controls.Add(listaSubastas);
            this.Controls.Add(btnActualizar);
            this.Controls.Add(txtSubastador);
            this.Controls.Add(txtArticulo);
            this.Controls.Add(txtPujaInicial);
            this.Controls.Add(txtIncremento);
            this.Controls.Add(txtDuracion);
            this.Controls.Add(btnCrearSubasta);
            this.Controls.Add(txtNumeroPostor);
            this.Controls.Add(txtNombrePostor);
            this.Controls.Add(btnCrearPostor);
            this.Controls.Add(txtOferta);
            this.Controls.Add(btnHacerOferta);

            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listaSubastas.Items.Clear();
            foreach (var subasta in sistema.SubastasActivas)
            {
                var item = new ListViewItem(subasta.Articulo);
                item.SubItems.Add(subasta.OfertaActual.ToString("C"));
                listaSubastas.Items.Add(item);
            }
        }

        private void BtnCrearSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreSub = txtSubastador.Text;
                string articulo = txtArticulo.Text;
                decimal pujaInicial = decimal.Parse(txtPujaInicial.Text);
                decimal incremento = decimal.Parse(txtIncremento.Text);
                int duracion = int.Parse(txtDuracion.Text);

                sistema.CrearSubasta(nombreSub, articulo, pujaInicial, incremento, DateTime.Now, duracion);
                ActualizarLista();
            }
            catch { MessageBox.Show("Revise los datos de la subasta."); }
        }

        private void BtnCrearPostor_Click(object sender, EventArgs e)
        {
            try
            {
                int nro = int.Parse(txtNumeroPostor.Text);
                string nombre = txtNombrePostor.Text;
                var postor = new Postor(nro, nombre);
                sistema.AgregarPostor(postor);
                MessageBox.Show($"Postor {nombre} creado.");
            }
            catch { MessageBox.Show("Revise los datos del postor."); }
        }

        private void BtnHacerOferta_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaSubastas.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione una subasta.");
                    return;
                }

                string articuloSeleccionado = listaSubastas.SelectedItems[0].Text;
                var subasta = sistema.SubastasActivas.Find(s => s.Articulo == articuloSeleccionado);

                int nroPostor = int.Parse(txtNumeroPostor.Text);
                var postor = sistema.Postores.Find(p => p.NumeroUnico == nroPostor);

                if (subasta != null && postor != null)
                {
                    decimal monto = decimal.Parse(txtOferta.Text);
                    if (!postor.SubastasActivas.Contains(subasta))
                        postor.UnirseASubasta(subasta);

                    postor.HacerOferta(subasta, monto);
                    ActualizarLista();
                }
            }
            catch { MessageBox.Show("Revise los datos de la oferta."); }
        }
    }
}
