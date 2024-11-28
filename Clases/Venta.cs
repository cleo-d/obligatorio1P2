using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Venta : Publicacion    
    {
        #region PROPERTYS
        public bool OfertaRelampago { get; set; }
        public double PrecioVenta { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Venta()
        {
            
        }

        public Venta(bool ofertaRelampago, double precioVenta, string Nombre, Estado Estado, DateTime FechaPublicacion)
            : base(Nombre, Estado, FechaPublicacion)
        {
            OfertaRelampago = ofertaRelampago;
            PrecioVenta = precioVenta;
            
        }
        #endregion
        private void CalcularPrecio()
        {
            double precioAux = 0;

            foreach (Articulo a in _listaArticulos)
            {
                precioAux += a.Precio;
            }


         validarOfertaRelampago(precioAux);
            

        }

        private void validarOfertaRelampago(double precioAux)
        {
            if (OfertaRelampago)
            {
                PrecioPublicacion = precioAux * 0.8;
            }
            else 
            {
                PrecioPublicacion = precioAux;
            }

        }
        

        private void ValidarSaldoParaVenta()
        {
            if (ClienteCompra.Saldo < PrecioPublicacion)
            {
                ClienteCompra = null;
                UsuarioCierre = null;
                throw new Exception("No tiene saldo para realizar la compra de la publicacion");
            }
        }
        public void AgregarArticulo(Articulo articulo)
        {
            try
            {
                articulo.Validar();
                _listaArticulos.Add(articulo);
                CalcularPrecio();


            }
            catch (Exception e) {
                throw;
            }
        }

        public override void CerrarPublicacion(Usuario u, double unMonto)
        {
            if (Estado == Estado.Abierta && u.Rol == "CLI")
            {
                    try
                    {

                    ClienteCompra = u as Cliente;
                    UsuarioCierre = u;
                    ValidarSaldoParaVenta();
                    RestarSaldoUsuario(ClienteCompra , unMonto);
                    Estado = Estado.Cerrada;
                    FechaCompra = DateTime.Now;
            

                    }
                catch (Exception e)
                    {

                    throw e;
                    }
            }
        }

        private void RestarSaldoUsuario(Cliente u, double unMonto)
        {
          u.Saldo -= unMonto;
        }

        public override void GetRol()
        {
            Rol = "VEN";
        }
        
    }
}
