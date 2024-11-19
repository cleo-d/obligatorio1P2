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
            BuscarMejorOferta();
            
        }

        public Subasta(string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
            BuscarMejorOferta();
            



        }
        #endregion
        public void AgregarOferta(Oferta unaOferta)
        {
            if(unaOferta.Monto > MejorOferta.Monto)
            {
                _listaOfertas.Add(unaOferta);
                BuscarMejorOferta();
            }
            //este metodo hay q verlo bien porque tal vez no hay q hacer el metodo Buscar mejor oferta
           
        }






        public override void CerrarPublicacion(Usuario u, double unMonto)
        {
            if (Estado == Estado.Abierta && u.Rol == "ADM")
            {
                BuscarMejorOferta();
           
                Estado = Estado.Cerrada;
                FechaCompra = DateTime.Now;
                ClienteCompra = MejorOferta.Cliente;
                UsuarioCierre = u;
                ClienteCompra.Saldo -= MejorOferta.Monto;


            }
        }


        //Busco la mejor oferta de la lista de ofertas de la subasta
        private void BuscarMejorOferta()
        {
            foreach (Oferta o in _listaOfertas)
            {
                

                if(o.Monto > PrecioPublicacion)
                {
                    PrecioPublicacion = o.Monto;
                    MejorOferta = o;
                }


            }
            
            
        }

        public override void GetRol()
        {
            Rol = "SUB";
        }
    }
}
