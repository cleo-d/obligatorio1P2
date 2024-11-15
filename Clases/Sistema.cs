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


        //Singleton
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
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
        public List<Cliente> GetClientes()
        {
            List<Cliente> clientesAux = new List<Cliente>();




            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente)
                {
                    clientesAux.Add((u as Cliente));
                }
            }
            if (clientesAux.Count == 0)
            {
                throw new Exception("La lista de clientes esta vacia");
            }
            return clientesAux;
        }
        //Metodo para dar de alta a un Usuario

        public void AltaCliente(Cliente c)
        {
            try
            {
                c.Validar();
                _usuarios.Add(c);
            }
            catch (Exception e)
            {

                throw e;
            }
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
            if (articulosPorCategoria.Count == 0)
            {
                throw new Exception("No se encontraron articulos dentro de esa categoria");
            }
            return articulosPorCategoria;
        }

        //Funcion para agregar un articulo
        public void AltaArticulo(string unNombre, string unaCategoria, double unPrecio)
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
            Administrador admin2 = new Administrador("Sofía", "Hernández", "s", "s");
            Administrador admin3 = new Administrador("David", "García", "david.garcia@example.com", "adminpass3");
            //Agrego los administradores a la lista de usuarios
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
            Cliente c6 = new Cliente(1500.00, "Hector", "Pérez", "hector.perez@example.com", "pass123");
            Cliente c7 = new Cliente(2000.50, "Pablo", "Gómez", "Pablo.gomez@example.com", "pass123");
            Cliente c8 = new Cliente(1200.75, "Daniel", "López", "daniel.lopez@example.com", "pass123");
            Cliente c9 = new Cliente(800.20, "Cecilia", "Martínez", "cecilia.martinez@example.com", "pass123");
            Cliente c10 = new Cliente(3000.00, "Leticia", "Fernández", "leticia.fernandez@example.com", "pass123");
            //Agrego los clientes a la lista de usuarios
            _usuarios.Add(c1);
            _usuarios.Add(c2);
            _usuarios.Add(c3);
            _usuarios.Add(c4);
            _usuarios.Add(c5);
            _usuarios.Add(c6);
            _usuarios.Add(c7);
            _usuarios.Add(c8);
            _usuarios.Add(c9);
            _usuarios.Add(c10);
        }

        private void PrecargaVentas()
        {
            Venta v1 = new Venta(true, 100, "Productos de Escritorio", Estado.Abierta, new DateTime(2023, 01, 23));
            Venta v2 = new Venta(true, 100, "Productos de Electronica", Estado.Abierta, new DateTime(2023, 02, 23));
            Venta v3 = new Venta(true, 100, "Instrumentos", Estado.Abierta, new DateTime(2023, 03, 23));
            Venta v4 = new Venta(true, 100, "Productos para Hogar", Estado.Abierta, new DateTime(2023, 04, 23));
            Venta v5 = new Venta(true, 100, "Productos de Cocina", Estado.Abierta, new DateTime(2023, 05, 23));
            Venta v6 = new Venta(true, 100, "Productos de Papeleria", Estado.Abierta, new DateTime(2023, 06, 23));
            Venta v7 = new Venta(true, 100, "Muebles", Estado.Abierta, new DateTime(2023, 07, 23));
            Venta v8 = new Venta(true, 100, "Accesorios", Estado.Abierta, new DateTime(2023, 08, 23));
            Venta v9 = new Venta(true, 100, "Ropa", Estado.Abierta, new DateTime(2023, 09, 23));
            Venta v10 = new Venta(true, 100, "Deportes", Estado.Abierta, new DateTime(2023, 10, 23));

            //Agrego articulos a las ventas
            v1.AgregarArticulo(GetArticuloPorNombre("Laptop"));
            v1.AgregarArticulo(GetArticuloPorNombre("Silla"));
            v1.AgregarArticulo(GetArticuloPorNombre("Mesa"));
            v1.AgregarArticulo(GetArticuloPorNombre("Monitor"));

            v2.AgregarArticulo(GetArticuloPorNombre("Laptop"));
            v2.AgregarArticulo(GetArticuloPorNombre("Mouse"));
            v2.AgregarArticulo(GetArticuloPorNombre("Teclado"));
            v2.AgregarArticulo(GetArticuloPorNombre("Monitor"));

            v3.AgregarArticulo(GetArticuloPorNombre("Laptop"));
            v3.AgregarArticulo(GetArticuloPorNombre("Piano"));
            v3.AgregarArticulo(GetArticuloPorNombre("Guitarra"));

            v4.AgregarArticulo(GetArticuloPorNombre("Silla"));
            v4.AgregarArticulo(GetArticuloPorNombre("Lavadora"));
            v4.AgregarArticulo(GetArticuloPorNombre("Mesa"));
            v4.AgregarArticulo(GetArticuloPorNombre("Secadora"));

            v5.AgregarArticulo(GetArticuloPorNombre("Licuadora"));
            v5.AgregarArticulo(GetArticuloPorNombre("Cafetera"));
            v5.AgregarArticulo(GetArticuloPorNombre("Tostadora"));

            v6.AgregarArticulo(GetArticuloPorNombre("Libro"));
            v6.AgregarArticulo(GetArticuloPorNombre("Estantería"));


            v8.AgregarArticulo(GetArticuloPorNombre("Audífonos"));
            v8.AgregarArticulo(GetArticuloPorNombre("Mochila"));


            v9.AgregarArticulo(GetArticuloPorNombre("Zapatos"));
            v9.AgregarArticulo(GetArticuloPorNombre("Camiseta"));


            v10.AgregarArticulo(GetArticuloPorNombre("Bicicleta"));
            v10.AgregarArticulo(GetArticuloPorNombre("Raqueta de tenis"));


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


            //v1.CerrarPublicacion();

        }
     
        private void PrecargaSubastas()
        {
            Subasta s1 = new Subasta("Limpieza", Estado.Abierta, new DateTime(2024, 01, 25));
            Subasta s2 = new Subasta("Instrumentos", Estado.Abierta, new DateTime(2024, 02, 25));
            Subasta s3 = new Subasta("Subasta3", Estado.Abierta, new DateTime(2024, 03, 25));
            Subasta s4 = new Subasta("Subasta4", Estado.Abierta, new DateTime(2024, 04, 25));
            Subasta s5 = new Subasta("Subasta5", Estado.Abierta, new DateTime(2024, 05, 25));
            Subasta s6 = new Subasta("Subasta6", Estado.Abierta, new DateTime(2024, 06, 25));
            Subasta s7 = new Subasta("Subasta7", Estado.Abierta, new DateTime(2024, 07, 25));
            Subasta s8 = new Subasta("Subasta8", Estado.Abierta, new DateTime(2024, 08, 25));
            Subasta s9 = new Subasta("Subasta9", Estado.Abierta, new DateTime(2024, 09, 25));
            Subasta s10 = new Subasta("Subasta10", Estado.Abierta, new DateTime(2024, 10, 25));

            //Agrego articulos a la lista de la subasta
            s1.AgregarArticulo(GetArticuloPorNombre("Lavadora"));
            s1.AgregarArticulo(GetArticuloPorNombre("Secadora"));
            s1.AgregarArticulo(GetArticuloPorNombre("Tostadora"));

            s2.AgregarArticulo(GetArticuloPorNombre("Guitarra"));
            s2.AgregarArticulo(GetArticuloPorNombre("Estuche de guitarra"));
            s2.AgregarArticulo(GetArticuloPorNombre("Parlante"));


            s3.AgregarArticulo(GetArticuloPorNombre("Laptop"));
            s3.AgregarArticulo(GetArticuloPorNombre("Piano"));
            s3.AgregarArticulo(GetArticuloPorNombre("Guitarra"));

            s4.AgregarArticulo(GetArticuloPorNombre("Silla"));
            s4.AgregarArticulo(GetArticuloPorNombre("Lavadora"));
            s4.AgregarArticulo(GetArticuloPorNombre("Mesa"));
            s4.AgregarArticulo(GetArticuloPorNombre("Secadora"));

            s5.AgregarArticulo(GetArticuloPorNombre("Licuadora"));
            s5.AgregarArticulo(GetArticuloPorNombre("Cafetera"));
            s5.AgregarArticulo(GetArticuloPorNombre("Tostadora"));

            s6.AgregarArticulo(GetArticuloPorNombre("Libro"));
            s6.AgregarArticulo(GetArticuloPorNombre("Estantería"));


            s8.AgregarArticulo(GetArticuloPorNombre("Audífonos"));
            s8.AgregarArticulo(GetArticuloPorNombre("Mochila"));


            s9.AgregarArticulo(GetArticuloPorNombre("Zapatos"));
            s9.AgregarArticulo(GetArticuloPorNombre("Camiseta"));


            s10.AgregarArticulo(GetArticuloPorNombre("Bicicleta"));
            s10.AgregarArticulo(GetArticuloPorNombre("Raqueta de tenis"));


            //Agrego ofertas a la subasta
            s1.AgregarOferta(new Oferta((GetClientePorNombre("Juan")), 125));
            s1.AgregarOferta(new Oferta((GetClientePorNombre("Carlos")), 350));

            s2.AgregarOferta(new Oferta((GetClientePorNombre("Ana")), 350));
            s2.AgregarOferta(new Oferta((GetClientePorNombre("Luis")), 350));
            




        

            

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
            List<Articulo> articulos = new List<Articulo>
        {
            new Articulo("Laptop", "Electrónica", 999.99),
            new Articulo("Teléfono", "Electrónica", 599.99),
            new Articulo("Silla", "Muebles", 120.50),
            new Articulo("Mesa", "Muebles", 200.00),
            new Articulo("Cámara", "Electrónica", 350.75),
            new Articulo("Libro", "Papelería", 15.99),
            new Articulo("Monitor", "Electrónica", 189.99),
            new Articulo("Teclado", "Accesorios", 49.99),
            new Articulo("Mouse", "Accesorios", 29.99),
            new Articulo("Impresora", "Electrónica", 250.00),
            new Articulo("Lámpara", "Hogar", 45.50),
            new Articulo("Zapatos", "Ropa", 75.99),
            new Articulo("Camiseta", "Ropa", 25.00),
            new Articulo("Refrigerador", "Electrodomésticos", 899.99),
            new Articulo("Lavadora", "Electrodomésticos", 750.00),
            new Articulo("Secadora", "Electrodomésticos", 600.00),
            new Articulo("Tostadora", "Electrodomésticos", 35.99),
            new Articulo("Audífonos", "Accesorios", 89.99),
            new Articulo("Mochila", "Accesorios", 55.00),
            new Articulo("Bicicleta", "Deportes", 450.00),
            new Articulo("Raqueta de tenis", "Deportes", 120.99),
            new Articulo("Guantes", "Accesorios", 29.99),
            new Articulo("Gorra", "Ropa", 19.99),
            new Articulo("Cámara de seguridad", "Electrónica", 120.00),
            new Articulo("Guitarra", "Instrumentos", 300.50),
            new Articulo("Piano", "Instrumentos", 1200.00),
            new Articulo("Batería", "Instrumentos", 700.00),
            new Articulo("Estuche de guitarra", "Accesorios", 75.00),
            new Articulo("Parlante", "Electrónica", 150.00),
            new Articulo("Televisor", "Electrónica", 1100.00),
            new Articulo("DVD Player", "Electrónica", 89.99),
            new Articulo("Auriculares inalámbricos", "Electrónica", 250.00),
            new Articulo("Tablet", "Electrónica", 499.99),
            new Articulo("Cargador portátil", "Accesorios", 39.99),
            new Articulo("Smartwatch", "Electrónica", 299.99),
            new Articulo("Microondas", "Electrodomésticos", 199.99),
            new Articulo("Ventilador", "Hogar", 75.00),
            new Articulo("Reloj de pared", "Hogar", 45.00),
            new Articulo("Cafetera", "Electrodomésticos", 99.99),
            new Articulo("Licuadora", "Electrodomésticos", 85.99),
            new Articulo("Olla de presión", "Cocina", 69.99),
            new Articulo("Set de cuchillos", "Cocina", 49.99),
            new Articulo("Toalla de baño", "Hogar", 25.99),
            new Articulo("Colchón", "Hogar", 450.00),
            new Articulo("Almohada", "Hogar", 30.00),
            new Articulo("Espejo", "Hogar", 75.50),
            new Articulo("Planta decorativa", "Hogar", 45.00),
            new Articulo("Estantería", "Muebles", 250.00)
            };

            _articulos.AddRange(articulos);



        }
        #endregion

        //Metodo para filtrar un articulo por nombre
        public Articulo GetArticuloPorNombre(string nombreArticulo)
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
            foreach (Cliente c in GetClientes())
            {
                if (c.Nombre == nombreCliente)
                {
                    return c;
                }
            }
            return null;
        }

        public Publicacion GetArticuloPorId(int id)
        {
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.Id == id)
                {
                    return publicacion;
                }
                
            }
            return null;
            //HAY QUE VALIDAR QUE NO RETURNE NULL CUANDO SE LLAMA A ESTA FUNCION
        }

		public Usuario Login(string email, string contrasenia)
		{
            foreach (Usuario u in _usuarios)
            {
                if(u.Email.Equals(email) && u.Contrasenia.Equals(contrasenia))
                {
                    return u;
                }
                
            }return null;
        }

        public Publicacion GetPublicacionPorId(int id)
        {
            Publicacion pEncontrada = null;
            foreach (Publicacion p in _publicaciones)
            {
                if(p.Id == id)
                {
                    pEncontrada = p;
                    break;
                }
            }
            return pEncontrada;
        }

        public Usuario GetUsuarioPorId(int? v)
        {
            foreach (Usuario u in _usuarios)
            {
                if(u.Id == v)
                {
                    return u;
                }
            }
            return null;
        }

		public void CargarSaldoUsuario(Usuario u, double saldo)
		{
			Cliente u2 = u as Cliente;

            u2.Saldo += saldo;
		}

        public Oferta AltaOferta(Cliente c, double unMonto)
        {
            Oferta o = null
            try
            {
              o = new Oferta(c, unMonto);
            }
            catch (Exception e)
            {
                throw e;
            }
            return o;
        }
    }

}
