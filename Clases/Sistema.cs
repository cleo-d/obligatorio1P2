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

        //Metodo para filtrar usuarios y deveolver clientes
        public List<Cliente> getClientes()
        {
            List<Cliente> clientesAux = new List<Cliente>();

            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente)
                {
                    clientesAux.Add((u as Cliente));
                }
            }

            return clientesAux;
        }

        //Metodo para obtener articulos por categoria
        public List<Articulo> GetArticulosPorCategoria(string categoria)
        {
            List<Articulo> articulosPorCategoria = new List<Articulo>();
            foreach (Articulo articulo in _articulos)
            {
                if (articulo.Categoria == categoria)
                {
                    articulosPorCategoria.Add(articulo);
                }
            }
            return articulosPorCategoria;
        }

        //Funcion para agregar un articulo
        public void altaArticulo(string unNombre, string unaCategoria, double unPrecio)
        {
            try
            {
                Articulo a = new Articulo(unNombre, unaCategoria, unPrecio);
                _articulos.Add(a);
            }
            catch (Exception e)
            {
                throw;
            }
            

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

            //Agrego articulos a las ventas
            v1.agregarArticulo(getArticuloPorNombre("Arroz"));
            v1.agregarArticulo(getArticuloPorNombre("Azúcar"));
            v1.agregarArticulo(getArticuloPorNombre("Harina"));
            v1.agregarArticulo(getArticuloPorNombre("Sal"));

            //Agrego las ventas a la lista de publicaciones
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
            Subasta s1 = new Subasta("Limpieza", Estado.Abierta, new DateTime(2024, 01, 25));
            //Agrego articulos a la lista de la subasta
            s1.agregarArticulo(getArticuloPorNombre("Jabón"));
            s1.agregarArticulo(getArticuloPorNombre("Detergente"));
            s1.agregarArticulo(getArticuloPorNombre("Desinfectante"));

            //Agrego ofertas a la subasta
            s1.agregarOferta(new Oferta((GetClientePorNombre("Juan")), 125));
            s1.agregarOferta(new Oferta((GetClientePorNombre("Carlos")), 350));

            Subasta s2 = new Subasta("Subasta2", Estado.Abierta, new DateTime(2024, 02, 25));
            Subasta s3 = new Subasta("Subasta3", Estado.Abierta, new DateTime(2024, 03, 25));
            Subasta s4 = new Subasta("Subasta4", Estado.Abierta, new DateTime(2024, 04, 25));
            Subasta s5 = new Subasta("Subasta5", Estado.Abierta, new DateTime(2024, 05, 25));
            Subasta s6 = new Subasta("Subasta6", Estado.Abierta, new DateTime(2024, 06, 25));
            Subasta s7 = new Subasta("Subasta7", Estado.Abierta, new DateTime(2024, 07, 25));
            Subasta s8 = new Subasta("Subasta8", Estado.Abierta, new DateTime(2024, 08, 25));
            Subasta s9 = new Subasta("Subasta9", Estado.Abierta, new DateTime(2024, 09, 25));
            Subasta s10 = new Subasta("Subasta10", Estado.Abierta, new DateTime(2024, 10, 25));

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

        //Metodo para filtrar un articulo por nombre
        public Articulo getArticuloPorNombre(string nombreArticulo)
        {
            foreach (Articulo a in _articulos)
            {
                if(a.Nombre == nombreArticulo) 
                {
                    return a;
                }
            }
            return null;
        }
        
        //Metodo para filtrar un cliente por nombre
        public Cliente GetClientePorNombre(string nombreCliente)
        {
            foreach (Cliente c in getClientes())
            {
                if (c.Nombre == nombreCliente)
                {
                    return c;
                }
            }
            return null;
        }

    }
}
