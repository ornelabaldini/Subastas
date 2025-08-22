using System;
using System.Collections.Generic;
using System.Linq;

namespace Subastas.Models
{
    public class SistemaSubastas
    {
        public List<Subasta> SubastasActivas { get; private set; }

        public SistemaSubastas()
        {
            SubastasActivas = new List<Subasta>();
        }

        public void CrearSubasta(string nombreSubastador, string articulo, decimal pujaInicial, decimal incremento, DateTime fecha, int duracion)
        {
            var subasta = new Subasta(nombreSubastador, articulo, pujaInicial, incremento, fecha, duracion);
            SubastasActivas.Add(subasta);
        }

        public void FinalizarSubastasVencidas()
        {
            var ahora = DateTime.Now;
            foreach (var subasta in SubastasActivas.ToList())
            {
                if ((ahora - subasta.Fecha).TotalMinutes >= subasta.DuracionMinutos)
                {
                    subasta.FinalizarSubasta();
                    SubastasActivas.Remove(subasta);
                }
            }
        }

        public Subasta ObtenerSubasta(string articulo)
        {
            return SubastasActivas.FirstOrDefault(s => s.Articulo == articulo);
        }
    }
}

