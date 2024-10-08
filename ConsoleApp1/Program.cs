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
            // Desplegar un menú en consola que permita:
            //      • Listado de todos los clientes.
            //      • Dado un nombre de categoría listar todos los artículos de esa categoría.
            //      • Alta de artículo.
            //      • Dadas dos fechas, listar las publicaciones entre esas fechas. Mostrar Id, nombre estado y fecha de
            //        publicación

            Console.WriteLine("---------------Menu principal---------------");
            Console.WriteLine("1-Mostrar listado de clientes");
            Console.WriteLine("2-Listar productos segun categoria");
            Console.WriteLine("3-Dar de alta a un articulo");
            Console.WriteLine("4-Listar publicaciones segun rango de fechas");
            Console.WriteLine();
            Console.WriteLine("0-Salir");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************************************");
            Console.WriteLine("-------Seleccione una opcion del menu-------");




            string opcion = "";

            while (opcion != "0")
            {
                //Leo opcion elegida por usuario
                opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        //Mostrar Lista de clientes
                        List<Cliente> clientesAux = s.getClientes();

                        if (clientesAux.Count > 0)
                        {
                            foreach (Cliente c in clientesAux)
                            {
                                Console.WriteLine($"-----------------------------------");
                                Console.WriteLine($"|Nombre Completo: {c.Nombre} {c.Apellido}");
                                Console.WriteLine($"|Email: {c.Email}");
                                Console.WriteLine($"|Saldo: {c.Saldo}");
                                Console.WriteLine($"-----------------------------------");

                            }
                        }
                        else
                        {
                            Console.WriteLine("No Existe ningun cliente ingresado");
                        }


                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("-------Seleccione otra opcion del menu-------");

                        break;
                    case "2":
                        Console.Write("Ingrese una categoria: ");

                        string inputCategoria = Console.ReadLine();
                        Console.WriteLine();

                        //Listar productos segun categoria
                        List<Articulo> articulosPorCategoria = s.GetArticulosPorCategoria(inputCategoria);
                        if (articulosPorCategoria.Count > 0)
                        {
                            foreach (Articulo a in articulosPorCategoria)
                            {

                                Console.WriteLine($"-------------------------");
                                Console.WriteLine($"|Nombre: {a.Nombre}");
                                Console.WriteLine($"|Categoria: {a.Categoria}");
                                Console.WriteLine($"|Precio: {a.Precio}");
                                Console.WriteLine($"-------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Existe la categoria ingresada");
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("-------Seleccione otra opcion del menu-------");
                        break;

                    case "3":
                        //Crear Articulo nuevo


                        try
                        {
                            Console.Write("Ingrese un nombre para el Articulo: ");
                            string inputNomArt = Console.ReadLine();

                            Console.Write("Ingrese una Categoria para el Articulo: ");
                            string inputCatArt = Console.ReadLine();
                            Console.Write("Ingrese un Precio para el Articulo: ");
                            double inputPrecioArt = int.Parse(Console.ReadLine());// validar en la excepcion cuando es vacio xq lo toma como string


                            s.altaArticulo(inputNomArt, inputCatArt, inputPrecioArt);
                            Console.WriteLine();
                            Console.WriteLine("--------------Articulo ingresado correctamente!--------------");
                            Console.WriteLine();
                            Console.WriteLine($"Nombre: {inputNomArt}, Categoria: {inputCatArt}, Precio: {inputPrecioArt}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("-------Seleccione otra opcion del menu-------");

                        break;

                    case "4":
                        //Listar publicaciones segun rango de fechas
                        //Todavia hay que terminar esto, hay que leer bien el input de la fecha y pasarlo a una instancia de DateTime
                        Console.Write("Ingrese una fecha de inicio con formato AAAA-MM-DD: ");
                        DateTime inputFecha1 = DateTime.Parse(Console.ReadLine());
                        Console.Write("Ingrese una fecha de finalizacion con formato AAAA-MM-DD: ");
                        DateTime inputFecha2 = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine(inputFecha1.ToString(), inputFecha2.ToString());

                        List<Publicacion> publicacionesAux = s.PublicacionesEntreFechas(inputFecha1, inputFecha2);
                        foreach (Publicacion p in publicacionesAux)
                        {
                            Console.WriteLine($"------------------------------");
                            Console.WriteLine($"|Id: {p.Id}");
                            Console.WriteLine($"|Nombre: {p.Nombre}");
                            Console.WriteLine($"|Estado: {p.Estado}");
                            Console.WriteLine($"|Fecha publicacion: {p.FechaPublicacion.ToShortDateString()}");
                            Console.WriteLine($"------------------------------");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("-------Seleccione otra opcion del menu-------");

                        break;

                    case "0":
                        Console.WriteLine("Saliendo del sistema");
                        break;

                    default:
                        Console.WriteLine("Por favor ingrese una opcion valida del menu");
                        break;
                }





            }
            Console.ReadKey();
            //End
        }
    }
}
