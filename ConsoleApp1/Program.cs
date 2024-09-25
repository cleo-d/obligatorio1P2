using Clases;
using System.ComponentModel.Design;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();
            //  3.Desplegar un menú en consola que permita:
            //      • Listado de todos los clientes.
            //      • Dado un nombre de categoría listar todos los artículos de esa categoría.
            //      • Alta de artículo.
            //      • Dadas dos fechas, listar las publicaciones entre esas fechas. Mostrar Id, nombre estado y fecha de
            //        publicación

            Console.WriteLine("Menu principal:");
            Console.WriteLine("1-Mostrar listado de clientes");
            Console.WriteLine("-------");

            List<Usuario> usuarios = s.GetUsuarios();
            
            foreach (Usuario u in usuarios)
            {
                if(u is Cliente)
                {
                    Cliente clienteAux = u as Cliente;
                    Console.WriteLine(clienteAux.Nombre);
                }
                
            }
            Console.WriteLine("-------");

            Console.WriteLine("2-Listar productos segun categoria");
            Console.WriteLine("-------");
            List<Articulo> articulosPorCategoria = s.GetArticulosPorCategoria("Limpieza");
            if (articulosPorCategoria.Count > 0)
            {
                foreach (Articulo Articulo in articulosPorCategoria)
                {
                    Console.WriteLine(Articulo.Nombre);
                }
            }
            Console.WriteLine("-------");

            Console.WriteLine("3-Dar de alta a un articulo");
            s.darAltaArticulo("Jabon1", "Limpieza", 80);

            List<Articulo> articulosAux = s.GetArticulos();

            foreach (Articulo a in articulosAux)
            {
            Console.WriteLine($"Nombre:  {a.Nombre }");

            }

            Console.WriteLine("-----------");
            Console.WriteLine("4-Listar publicaciones segun rango de fechas");

            List <Publicacion> publicacionesAux = s.PublicacionesEntreFechas(new DateTime(2024, 01, 25), new DateTime(2024, 05, 25));

            foreach (Publicacion p in publicacionesAux)
            {
                Console.WriteLine($"Id: {p.Id} Nombre: {p.Nombre} Estado: {p.Estado}");
            }


            Console.WriteLine("0-Salir");


            Console.ReadKey();

        }
    }
}
