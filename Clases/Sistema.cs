using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();

        private static Sistema _instancia;

        private Sistema()
        {
            PrecargaDatos();
        }



        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                return new Sistema();
            }
            return _instancia;
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarios;
        }
        public List<Publicacion> GetPublicaciones()
        {
            return _publicaciones;
        }
        public List<Articulo> GetArticulos()
        {
            return _articulos;
        }

        public List<Articulo> GetArticulosPorCategoria(string categoria)
        {
            List<Articulo> articulosPorCategoria = new List<Articulo>();
            foreach (Articulo articulo in _articulos)
            {
                if(articulo.Categoria == categoria)
                {
                    articulosPorCategoria.Add(articulo);
                }
            }
            return articulosPorCategoria;
        }

        //Funcion para agregar un articulo
        public void darAltaArticulo(string unNombre, string unaCategoria, double unPrecio)
        {

            Articulo a = new Articulo(unNombre,unaCategoria,unPrecio);
            _articulos.Add(a);

        }

        //Funcion para listar publicaciones dentro de determinadas fechas
        public List<Publicacion> PublicacionesEntreFechas(DateTime primerFecha, DateTime segundaFecha)
        {
            List<Publicacion> publicacionesEntreFechas = new List<Publicacion>();
            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion > primerFecha && p.FechaPublicacion < segundaFecha)
                {
                   publicacionesEntreFechas.Add(p);
                }

            }
            return publicacionesEntreFechas;

        }

        #region PRECARGADATOS


        private void PrecargaDatos()
        {
            PrecargaArticulos();
            PrecargaClientes();         
            PrecargaAdministradores();
            PrecargaSubastas();
            PrecargaVentas(); 

        }


        private void PrecargaAdministradores()
        {
            Administrador admin1 = new Administrador("Pedro", "Rodríguez", "pedro.rodriguez@example.com", "adminpass1");
            Administrador admin2 = new Administrador("Sofía", "Hernández", "sofia.hernandez@example.com", "adminpass2");
            Administrador admin3 = new Administrador("David", "García", "david.garcia@example.com", "adminpass3");
            _usuarios.Add(admin1);
            _usuarios.Add(admin2);
            _usuarios.Add(admin3);
        }

        private void PrecargaClientes()
        {
            Cliente c1 = new Cliente(1500.00, "Juan", "Pérez", "juan.perez@example.com", "pass123");
            Cliente c2 = new Cliente(2000.50, "María", "Gómez", "maria.gomez@example.com", "mariapass");
            Cliente c3 = new Cliente(1200.75, "Carlos", "López", "carlos.lopez@example.com", "carlospass");
            Cliente c4 = new Cliente(800.20, "Ana", "Martínez", "ana.martinez@example.com", "anapass");
            Cliente c5 = new Cliente(3000.00, "Luis", "Fernández", "luis.fernandez@example.com", "luifernpass");
            _usuarios.Add(c1);
            _usuarios.Add(c2);
            _usuarios.Add(c3);
            _usuarios.Add(c4);
            _usuarios.Add(c5);
        }

        private void PrecargaVentas()
        {
            Venta v1 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 01, 23));
            Venta v2 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 02, 23));
            Venta v3 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 03, 23));
            Venta v4 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 04, 23));
            Venta v5 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 05, 23));
            Venta v6 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 06, 23));
            Venta v7 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 07, 23));
            Venta v8 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 08, 23));
            Venta v9 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 09, 23));
            Venta v10 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 10, 23));


            _publicaciones.Add(v1);
            _publicaciones.Add(v2);
            _publicaciones.Add(v3);
            _publicaciones.Add(v4);
            _publicaciones.Add(v5);
            _publicaciones.Add(v6);
            _publicaciones.Add(v7);
            _publicaciones.Add(v8);
            _publicaciones.Add(v9);
            _publicaciones.Add(v10);

        }

        private void PrecargaSubastas()
        {
            Subasta s1 = new Subasta(crearOfertas(2), "Subasta1", Estado.Abierta, new DateTime(2024, 01, 25));
            Subasta s2 = new Subasta(crearOfertas(4), "Subasta2", Estado.Abierta, new DateTime(2024, 02, 25));
            Subasta s3 = new Subasta(null, "Subasta3", Estado.Abierta, new DateTime(2024, 03, 25));
            Subasta s4 = new Subasta(null, "Subasta4", Estado.Abierta, new DateTime(2024, 04, 25));
            Subasta s5 = new Subasta(null, "Subasta5", Estado.Abierta, new DateTime(2024, 05, 25));
            Subasta s6 = new Subasta(null, "Subasta6", Estado.Abierta, new DateTime(2024, 06, 25));
            Subasta s7 = new Subasta(null, "Subasta7", Estado.Abierta, new DateTime(2024, 07, 25));
            Subasta s8 = new Subasta(null, "Subasta8", Estado.Abierta, new DateTime(2024, 08, 25));
            Subasta s9 = new Subasta(null, "Subasta9", Estado.Abierta, new DateTime(2024, 09, 25));
            Subasta s10 = new Subasta(null, "Subasta10", Estado.Abierta, new DateTime(2024, 10, 25));

            _publicaciones.Add(s1);
            _publicaciones.Add(s2);
            _publicaciones.Add(s3);
            _publicaciones.Add(s4);
            _publicaciones.Add(s5);
            _publicaciones.Add(s6);
            _publicaciones.Add(s7);
            _publicaciones.Add(s8);
            _publicaciones.Add(s9);
            _publicaciones.Add(s10);

        }

        private List<Oferta> crearOfertas(int unaCantidad)
        {
            List<Oferta> ofertasAux = new List<Oferta>();

            for (int i = 0; i < unaCantidad; i++)
            {
                Oferta oferta = new Oferta(new Cliente(10000 + i, "Cliente", "ofertaPrecarga", "cliente.precarga@example.com", "pass123"), 200 + i, new DateTime(2024, 06, 25));
            }

            return ofertasAux;
        }

        private void PrecargaArticulos()
        {
            Articulo a1 = new Articulo("Arroz", "Alimentos", 50.00);
            Articulo a2 = new Articulo("Harina", "Alimentos", 40.00);
            Articulo a3 = new Articulo("Jabón", "Limpieza", 30.00);
            Articulo a4 = new Articulo("Detergente", "Limpieza", 80.00);
            Articulo a5 = new Articulo("Aceite", "Alimentos", 120.00);
            Articulo a6 = new Articulo("Fósforos", "Hogar", 10.00);
            Articulo a7 = new Articulo("Azúcar", "Alimentos", 45.00);
            Articulo a8 = new Articulo("Sal", "Alimentos", 20.00);
            Articulo a9 = new Articulo("Desinfectante", "Limpieza", 90.00);
            Articulo a10 = new Articulo("Papel Higiénico", "Higiene", 60.00);
            _articulos.Add(a1);
            _articulos.Add(a2);
            _articulos.Add(a3);
            _articulos.Add(a4);
            _articulos.Add(a5);
            _articulos.Add(a6);
            _articulos.Add(a7);
            _articulos.Add(a8);
            _articulos.Add(a9);
            _articulos.Add(a10);
            

        }
        #endregion
    }
}
