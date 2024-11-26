using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public abstract class Publicacion : IValidable , IComparable<Publicacion>
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


        public List<Articulo> GetArticulos()
        {
            return _listaArticulos;
        }

        //motodo que agregue un articulo a la lista de articulos de la publicacion
        public void AgregarArticulo(Articulo unArticulo)
        {
            _listaArticulos.Add(unArticulo);
        }

        public abstract void CerrarPublicacion(Usuario u, double unMonto);
        public abstract void GetRol();
        
        public int CompareTo(Publicacion otra)
        {
            return FechaPublicacion.CompareTo(otra.FechaPublicacion);
        }

    }
}
