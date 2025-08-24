using System;
using System.Collections.Generic;

namespace Subastas.Models
{
    public class SistemaSubastas
    {
        public List<Subasta> SubastasActivas { get; private set; }
        public List<Postor> Postores { get; private set; }

        public SistemaSubastas()
        {
            SubastasActivas = new List<Subasta>();
            Postores = new List<Postor>();
        }

        public void CrearSubasta(string subastador, string articulo, decimal pujaInicial, decimal incremento, DateTime fecha, int duracion)
        {
            var subasta = new Subasta(subastador, articulo, pujaInicial, incremento, fecha, duracion);
            SubastasActivas.Add(subasta);
        }

        public void AgregarPostor(Postor postor)
        {
            if (!Postores.Contains(postor))
            {
                Postores.Add(postor);
            }
        }

        public void EliminarPostor(Postor postor)
        {
            if (Postores.Contains(postor))
            {
                Postores.Remove(postor);
            }
        }
    }
}
