namespace Subastas.Models
{
    public class Subasta
    {
        public string Articulo { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal OfertaActual { get; private set; }

        public Subasta(string articulo, decimal precioInicial)
        {
            Articulo = articulo;
            PrecioInicial = precioInicial;
            OfertaActual = precioInicial;
        }

        public void Ofertar(decimal monto)
        {
            if (monto > OfertaActual)
                OfertaActual = monto;
        }
    }
}
