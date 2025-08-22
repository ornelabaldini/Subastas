using System;
using System.Windows.Forms;

namespace Subastas.Views
{
    public class SubastaForm : Form
    {
        private Label _lblArticulo;
        private Label _lblOferta;
        private TextBox _txtOferta;
        private Button _btnOfertar;

        public event Action<decimal> OnOferta;

        public SubastaForm()
        {
            Text = "Subasta";
            Width = 400;
            Height = 200;

            _lblArticulo = new Label { Top = 20, Left = 20, Width = 300 };
            _lblOferta   = new Label { Top = 50, Left = 20, Width = 300 };
            _txtOferta   = new TextBox { Top = 80, Left = 20, Width = 200 };
            _btnOfertar  = new Button { Text = "Ofertar", Top = 110, Left = 20 };

            _btnOfertar.Click += (s, e) =>
            {
                if (decimal.TryParse(_txtOferta.Text, out var monto))
                    OnOferta?.Invoke(monto);
            };

            Controls.Add(_lblArticulo);
            Controls.Add(_lblOferta);
            Controls.Add(_txtOferta);
            Controls.Add(_btnOfertar);
        }

        public void MostrarSubasta(string articulo, decimal precioInicial)
        {
            _lblArticulo.Text = $"Artículo: {articulo}";
            _lblOferta.Text   = $"Oferta actual: {precioInicial:C}";
        }

        public void MostrarOferta(decimal oferta)
        {
            _lblOferta.Text = $"Oferta actual: {oferta:C}";
        }
    }
}
