using System;
using System.Collections.Generic;
using System.Linq;

namespace Subastas.Models
{
    public class Subasta
    {
        public string NombreSubastador { get; set; }
        public string Articulo { get; set; }
        public decimal PujaInicial { get; set; }
        public decimal Incremento { get; set; }
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
        public List<Postor> Postores { get; private set; }
        public decimal OfertaActual { get; private set; }
        public Postor Ganador { get; private set; }

        public Subasta(string nombreSubastador, string articulo, decimal pujaInicial, decimal incremento, DateTime fecha, int duracionMinutos)
        {
            NombreSubastador = nombreSubastador;
            Articulo = articulo;
            PujaInicial = pujaInicial;
            Incremento = incremento;
            Fecha = fecha;
            DuracionMinutos = duracionMinutos;
            OfertaActual = pujaInicial;
            Postores = new List<Postor>();
        }

        public void AgregarPostor(Postor postor)
        {
            if (!Postores.Contains(postor))
                Postores.Add(postor);
        }

        public void EliminarPostor(Postor postor)
        {
            if (Postores.Contains(postor))
                Postores.Remove(postor);
        }

        public void RecibirOferta(Postor postor, decimal monto)
        {
            if (monto > OfertaActual)
                OfertaActual = monto;
        }

        public void FinalizarSubasta()
        {
            if (Postores.Count == 0 || OfertaActual == PujaInicial)
            {
                Ganador = null; // Sin ofertas
            }
            else
            {
                Ganador = Postores.Last();
            }
        }

        public decimal Diferencia()
        {
            return OfertaActual - PujaInicial;
        }
    }
}
