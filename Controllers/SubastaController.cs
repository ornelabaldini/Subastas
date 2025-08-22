using Subastas.Models;
using Subastas.Views;

namespace Subastas.Controllers
{
    public class SubastaController
    {
        private readonly SubastaForm _view;
        private readonly Subasta _model;

        public SubastaController(SubastaForm view)
        {
            _view = view;
            _model = new Subasta("Notebook Gamer", 50000);

            _view.OnOferta += HandleOferta;
            _view.MostrarSubasta(_model.Articulo, _model.PrecioInicial);
        }

        private void HandleOferta(decimal monto)
        {
            _model.Ofertar(monto);
            _view.MostrarOferta(_model.OfertaActual);
        }
    }
}
