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

            mostrarMenu();




            string opcion = "";

            while (opcion != "0")
            {
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        //Mostrar Lista de clientes
                        try
                        {
                            List<Cliente> clientesAux = s.getClientes();

                            foreach (Cliente c in clientesAux)
                            {
                                Console.WriteLine($"-----------------------------------");
                                Console.WriteLine($"|Nombre Completo: {c.Nombre} {c.Apellido}");
                                Console.WriteLine($"|Email: {c.Email}");
                                Console.WriteLine($"|Saldo: {c.Saldo}");
                                Console.WriteLine($"-----------------------------------");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(e.Message);
                            Console.WriteLine($"-------------------------");
                        }

                        mostrarMenu();
                        break;

                    case "2":
                        Console.WriteLine("Indique una categoria");
                        string inputCategoria = Console.ReadLine();

                        //Listar productos segun categoria
                        try
                        {
                            validarVacio( inputCategoria );
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
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(e.Message);
                            Console.WriteLine($"-------------------------");
                        }
                        mostrarMenu();
                        break;

                    case "3":
                        //Crear Articulo nuevo
                        Console.WriteLine("Ingrese un nombre para el Articulo");
                        string inputNomArt = Console.ReadLine();
                        Console.WriteLine("Ingrese una Categoria para el Articulo");
                        string inputCatArt = Console.ReadLine();
                        Console.WriteLine("Ingrese un Precio para el Articulo");

                        try
                        {
                            double inputPrecioArt = double.Parse(Console.ReadLine());
                            validarVacio(inputNomArt);
                            validarVacio(inputCatArt);
                            //En la clase articulo se valida las reglas de negocio para la cracion de Articulos
                            s.altaArticulo(inputNomArt, inputCatArt, inputPrecioArt);

                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"Articulo ingresado correctamente!");
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"|Nombre: {inputNomArt}");
                            Console.WriteLine($"|Categoria: {inputCatArt}");
                            Console.WriteLine($"|Precio: {inputPrecioArt}");
                            Console.WriteLine($"-------------------------");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(e.Message);
                            Console.WriteLine($"-------------------------");
                        }
                        mostrarMenu();
                        break;

                    case "4":

                        try
                        {
                            // Listar publicaciones según rango de fechas
                            Console.WriteLine("Ingrese una fecha de inicio con formato AAAA-MM-DD:");
                            DateTime inputFecha1;
                            if (!DateTime.TryParse(Console.ReadLine(), out inputFecha1))
                            {
                                throw new FormatException("La fecha de inicio no es válida.");
                            }

                            Console.WriteLine("Ingrese una fecha de finalización con formato AAAA-MM-DD:");
                            DateTime inputFecha2;
                            if (!DateTime.TryParse(Console.ReadLine(), out inputFecha2))
                            {
                                throw new FormatException("La fecha de finalización no es válida.");
                            }

                            if (inputFecha1 > inputFecha2)
                            {
                                throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de finalización.");
                            }

                            List<Publicacion> publicacionesAux = s.PublicacionesEntreFechas(inputFecha1, inputFecha2);
                            if (publicacionesAux.Count != 0)
                            {
                                foreach (Publicacion p in publicacionesAux)
                                {
                                    Console.WriteLine($"Id: {p.Id} Nombre: {p.Nombre} Estado: {p.Estado}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"-------------------------");
                                Console.WriteLine("No se encontraron publicaciones en el rango de fechas ingresadas");
                                Console.WriteLine($"-------------------------");
                            }
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(fe.Message);
                            Console.WriteLine($"-------------------------");
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(ae.Message);
                            Console.WriteLine($"-------------------------");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"-------------------------");
                            Console.WriteLine($"----------ERROR----------");
                            Console.WriteLine(e.Message);
                            Console.WriteLine($"-------------------------");
                        }
                        mostrarMenu();
                        break;

                case "0":
                    Console.WriteLine("Saliendo del sistema");
                    break;

                    default:
                        Console.WriteLine("Por favor ingrese una opcion del menu");
                        break;
                }


            }
            Console.ReadKey();
            //End

        }

        //Validacion basica para verificar que un input no sea Null o Empty
        private static void validarVacio(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new Exception("El dato no puede ser vacio");
            }
        }

        private static void mostrarMenu()
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************");
            Console.WriteLine("-------Seleccione una opcion del menu -------");
                Console.WriteLine("1-Mostrar listado de clientes");
                Console.WriteLine("2-Listar productos segun categoria");
                Console.WriteLine("3-Dar de alta a un articulo");
                Console.WriteLine("4-Listar publicaciones segun rango de fechas");
                Console.WriteLine();
                Console.WriteLine("0-Salir");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************");
            }
    }
}
