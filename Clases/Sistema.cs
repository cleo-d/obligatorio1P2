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
        
        //public List<Articulo> PublicacionesEntreFechas(DateTime primerFecha,DateTime segundaFecha)
        //{
        //    List<Articulo> articulosEntreFechas = new List<Articulo>();
        //    foreach (Articulo articulo in _articulos)
        //    {

                
        //    }
        //    return articulosEntreFechas;

        //}

        #region PRECARGADATOS

        
        private void PrecargaDatos()
        {
            PrecargaArticulos();
            PrecargaClientes();         
            PrecargaAdministradores();
            //PrecargaSubastas();
            //PrecargaVentas(); 

        }

        //private void PrecargaSubastas()
        //{
        //    throw new NotImplementedException();
        //}

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

        //private void PrecargaVentas()
        //{
        //    Venta v1 = new Venta(true, 100, "Limpieza", Estado.Abierta, new DateTime(2023, 09, 23));
            
        //    _publicaciones.Add(v1);
            
        //}
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
