using System.Collections.Generic;

namespace Subastas.Models
{
    public class Postor
    {
        public int NumeroUnico { get; set; }
        public string Nombre { get; set; }
        public List<Subasta> SubastasActivas { get; private set; }

        public Postor(int numero, string nombre)
        {
            NumeroUnico = numero;
            Nombre = nombre;
            SubastasActivas = new List<Subasta>();
        }

        public void UnirseASubasta(Subasta subasta)
        {
            if (!SubastasActivas.Contains(subasta))
            {
                SubastasActivas.Add(subasta);
                subasta.AgregarPostor(this);
            }
        }

        public void SalirDeSubasta(Subasta subasta)
        {
            if (SubastasActivas.Contains(subasta))
            {
                SubastasActivas.Remove(subasta);
                subasta.EliminarPostor(this);
            }
        }

        public void HacerOferta(Subasta subasta, decimal monto)
        {
            if (SubastasActivas.Contains(subasta))
            {
                subasta.RecibirOferta(this, monto);
            }
        }
    }
}
