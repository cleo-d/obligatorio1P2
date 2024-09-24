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


            Console.WriteLine("4-Listar publicaciones segun rango de fechas");
            Console.WriteLine("0-Salir");


            Console.ReadKey();

        }
    }
}
