using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Articulo
    {
        #region PROPERTYS
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public string Nombre  { get; set; }
        public string Categoria { get; set; }

        public double Precio { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Articulo()
        {
            Id = UltimoId++;
        }

        public Articulo(string nombre, string categoria, double precio)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Validar();
        }
        #endregion

        public void Validar()
        {
            ValidarNombre();
            ValidarCategoria();
            ValidarPrecio();
        }



        private void ValidarNombre()
        {
           if(String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
        }
        private void ValidarCategoria()
        {
            if (String.IsNullOrEmpty(Categoria))
            {
                throw new Exception("La categoria no puede estar vacia");
            }
        }
        private void ValidarPrecio()
        {
            if (Precio<0)
            {
                throw new Exception("El precio del artiulo tiene que ser un numero positivo");
            }
        }
    }
}
