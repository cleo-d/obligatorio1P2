using System;
using System.Collections.Generic;
using System.Linq;
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
            validar();
        }
        #endregion

        private void validar()
        {
          //Este Metodo de ValidarSaldoParaVenta no se tendria que correr al momento que un usuario quiera hacer una compra?
          //Dejo este metodo comentado ->
          //  ValidarSaldoParaVenta();
        }

        private void ValidarSaldoParaVenta()
        {
            if (ClienteCompra.Saldo < PrecioVenta)
            {
                throw new Exception("No tiene saldo para realizar la compra de la publicacion");
            }
        }
        public void agregarArticulo(Articulo articulo)
        {
            try
            {
                articulo.Validar();
                _listaArticulos.Add(articulo);
            }
            catch (Exception e) {
                throw;
            }
        }
    }
}
