using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    //Esta clase podria ser abstracta y los metodos de Agregar Articulo (O VIRTUAL) estarian aca para poder agregar articulso desde una venta u subasta
    public abstract class Publicacion : IValidable
    {
        #region PROPERTYS
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<Articulo> _listaArticulos { get; set; } = new List<Articulo>();

        public DateTime FechaCompra { get; set; }

        public Cliente ClienteCompra { get; set; }
        public Usuario UsuarioCierre { get; set; }

        public string Rol { get; set; }

        public double PrecioPublicacion { get; set; }
        //Agregar Metodo que agarre el precio de la Venta o la mejor oferta de la Subasta
        #endregion
       #region CONSTRUCTORES
        public Publicacion()
        {
            Id = UltimoId++;
            GetRol();
            
        }

        public Publicacion(string nombre, Estado estado, DateTime fechaPublicacion)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Validar();
            GetRol();
            
        }
        #endregion

        public void Validar()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre de la publicacion no puede ser vacia");
            }
        }


        //get articulos

        public List<Articulo> GetArticulos()
        {
            return _listaArticulos;
        }

        //motodo que agregue un articulo a la lista de articulos de la punblicacion
        public void AgregarArticulo(Articulo unArticulo)
        {
            _listaArticulos.Add(unArticulo);
        }

        public abstract void CerrarPublicacion(Usuario u);
        public abstract void GetRol();
        

    }
}
