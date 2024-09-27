﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Publicacion
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
        #endregion
        #region CONSTRUCTORES
        public Publicacion()
        {
            Id = UltimoId++;
        }

        public Publicacion(string nombre, Estado estado, DateTime fechaPublicacion)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Validar();
        }
        #endregion

        private void Validar()
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

        public List<Articulo> getArticulos()
        {
            return _listaArticulos;
        }

        //motodo que agregue un articulo a la lista de articulos de la punblicacion
        public void agregarArticulo(Articulo unArticulo)
        {
            _listaArticulos.Add(unArticulo);
        }
    }
}
