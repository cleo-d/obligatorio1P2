using System;
using System.Collections.Generic;
using System.Data;
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
            //BuscarMejorOferta();
            
        }

        public Subasta(string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
            //BuscarMejorOferta();
            



        }
        #endregion
        public void AgregarOferta(Oferta unaOferta)
        {
            
            if(unaOferta.Monto > PrecioPublicacion)
            {
                PrecioPublicacion = unaOferta.Monto;
                _listaOfertas.Add(unaOferta);
                MejorOferta = unaOferta;
            }
                else
                {
                    throw new Exception("La oferta debe ser superior al precio que ya fue ofertado");
                }
           
        }
        public override void CerrarPublicacion(Usuario u, double unMonto)
        {
            if (Estado == Estado.Abierta && u.Rol == "ADM")
            {
                
                Estado = Estado.Cerrada;
                FechaCompra = DateTime.Now;
                validarClienteCompra(u);
            }
        }

        private void validarClienteCompra(Usuario u)
        {
            if(MejorOferta != null)
            {
                ClienteCompra = MejorOferta.Cliente;
                UsuarioCierre = u;
                ClienteCompra.Saldo -= MejorOferta.Monto;
            }
        }

        public override void GetRol()
        {
            Rol = "SUB";
        }
    }
}
