using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clases
{
    public class Subasta : Publicacion
    {
        #region PROPERTYS
        public List<Oferta> _listaOfertas { get; set; } = new List<Oferta>();
        public Oferta MejorOferta { get; set; }
        #endregion
        #region CONSTRUCTORES
        public Subasta()
        {
            
        }

        public Subasta(string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
           
            
           
        }
        #endregion
        public void AgregarOferta(Oferta unaOferta)
        {
            _listaOfertas.Add(unaOferta);
        }






        public override void CerrarPublicacion()
        {
            if (Estado == Estado.Abierta)
            {
                BuscarMejorOferta();
                Estado = Estado.Cerrada;
                FechaCompra = DateTime.Now;
                ClienteCompra = MejorOferta.Cliente;


            }
        }


        //Busco la mejor oferta de la lista de ofertas de la subasta
        private void BuscarMejorOferta()
        {
            double montoOferta = 0;

            foreach (Oferta o in _listaOfertas)
            {
                

                if(o.Monto > montoOferta)
                {
                    montoOferta = o.Monto;
                    MejorOferta = o;
                }

            }
        }
    }
}
