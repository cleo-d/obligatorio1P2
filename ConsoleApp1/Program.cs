using Clases;
using System.ComponentModel.Design;
using System.Diagnostics;

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
            Console.WriteLine("2-Listar productos segun categoria");
            Console.WriteLine("3-Dar de alta a un articulo");
            Console.WriteLine("4-Listar publicaciones segun rango de fechas");
            Console.WriteLine("0-Salir");

            //Leo opcion elegida por usuario
            string inputUsuario = Console.ReadLine();

            switch (inputUsuario)
            {
                case "1":
                    //Mostrar Lista de clientes
                    List<Cliente> clientesAux = s.getClientes();
            
                    foreach (Cliente c in clientesAux)
                    {
                            Console.WriteLine(c.Nombre);
                    }
                    break;
                case "2":
                    Console.WriteLine("Indique una categoria");
                    string inputCategoria = Console.ReadLine();

                    //Listar productos segun categoria
                    List<Articulo> articulosPorCategoria = s.GetArticulosPorCategoria(inputCategoria);
                    if (articulosPorCategoria.Count > 0)
                    {
                        foreach (Articulo Articulo in articulosPorCategoria)
                        {
                            Console.WriteLine(Articulo.Nombre);
                        }
                    }
                    break;

                case "3":
                    //Crear Articulo nuevo
                    Console.WriteLine("Ingrese un nombre para el Articulo");
                    string inputNomArt = Console.ReadLine();
                    Console.WriteLine("Ingrese una Categoria para el Articulo");
                    string inputCatArt = Console.ReadLine();
                    Console.WriteLine("Ingrese un Precio para el Articulo");
                    double inputPrecioArt = int.Parse(Console.ReadLine());

                    try
                    {
                        s.altaArticulo(inputNomArt, inputCatArt, inputPrecioArt);
                        Console.WriteLine($"Articulo ingresado correctamente! \n" +
                                          $"Nombre: {inputNomArt}, Categoria: {inputCatArt}, Precio: {inputPrecioArt}");
                    }
                    catch (Exception e) 
                    { 
                      Console.WriteLine(e.Message); 
                    }



                    break;

                case "4":
                    //Listar publicaciones segun rango de fechas
                    //Todavia hay que terminar esto, hay que leer bien el input de la fecha y pasarlo a una instancia de DateTime
                    Console.WriteLine("Ingrese una fecha de inicio con formato AAAA-MM-DD");
                    DateTime inputFecha1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese una fecha de finalizacion con formato AAAA-MM-DD");
                    DateTime inputFecha2 = DateTime.Parse(Console.ReadLine()); ;

                    Console.WriteLine(inputFecha1.ToString(),  inputFecha2.ToString());

                    List<Publicacion> publicacionesAux = s.PublicacionesEntreFechas(inputFecha1,inputFecha2);
                    foreach (Publicacion p in publicacionesAux)
                    {
                        Console.WriteLine($"Id: {p.Id} Nombre: {p.Nombre} Estado: {p.Estado}");
                    }

                    break;

                case "0":
                    Console.WriteLine("Saliendo del sistema");
                    break;

                default:
                    Console.WriteLine("Por favor ingrese una opcion del menu");
                    break;
            }

            Console.ReadKey();




            //End
        }
    }
}
