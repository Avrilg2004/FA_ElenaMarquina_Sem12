using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana12
{
    internal class Libreria
    {
        string[] libros = new string[0];
        double[] precios = new double[0];
        string nombre;

        public void Registrar()
        {
            string nombre;
            double pc;
            int lb_r;

            while (true)
            {
                lb_r = 0;

                Console.Write("\nIngrese el nombre del libro (o escriba 'salir' para terminar): ");
                nombre = Console.ReadLine().Trim().ToLower();

                if (nombre == "salir")
                {
                    break;
                }

                if (nombre.Trim() == "")
                {
                    Console.WriteLine("¡ERROR! El nombre no puede estar vacío.");
                }
                else
                {

                    for (int j = 0; j < libros.Length; j++)
                    {
                        if (libros[j] == nombre)
                        {
                            lb_r = 1;
                            Console.WriteLine("¡ERROR! Libro ya registrado.");
                        }
                    }

                    if (lb_r == 0)
                    {

                        bool precioValido = false;

                        do
                        {
                            Console.Write("Ingrese el precio del libro: ");
                            if (double.TryParse(Console.ReadLine(), out pc) && pc > 0 && pc <= 1000)
                            {
                                precioValido = true;
                            }
                            else
                            {
                                Console.WriteLine("¡ERROR! Precio inválido (entre 1 y 1000).");
                            }
                        } while (precioValido == false);

                        Array.Resize(ref libros, libros.Length + 1);
                        Array.Resize(ref precios, precios.Length + 1);

                        libros[libros.Length - 1] = nombre;
                        precios[precios.Length - 1] = pc;

                        Console.WriteLine("Libro registrado correctamente.");
                    }
                }
            }
        }

        public void Mostrar()
        {
            if (libros.Length == 0)
            {
                Console.WriteLine("\nNo hay libros registrados aún.");
            }

            else
            {
                Console.WriteLine("\nN°\tLibro\t\t\tPrecio");
                Console.WriteLine("------------------------------------------");

                for (int i = 0; i < libros.Length; i++)
                {
                    Console.WriteLine($"{i + 1}\t{libros[i]}\t\tS/. {precios[i]}");
                }
            }
        }

        public void Modificar()
        {
            string buscar;
            int pos = Array.IndexOf(libros, nombre);

            if (libros.Length == 0)
            {
                Console.WriteLine("\nNo hay libros para modificar.");
                return;
            }
           
            Console.Write("\nIngrese el nombre del libro que desea modificar: ");
            buscar = Console.ReadLine();

            pos = -1;

            for (int i = 0; i < libros.Length; i++)
            {
                if (libros[i].ToLower() == buscar.ToLower())
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("El libro no existe.");
            }

            else
            {
                Console.WriteLine("\nLibro encontrado:");
                Console.WriteLine($"Nombre: {libros[pos]}, Precio: S/. {precios[pos]}");

                Console.WriteLine("\n¿Qué desea modificar?");
                Console.WriteLine("[ 1 ] Nombre");
                Console.WriteLine("[ 2 ] Precio");
                Console.WriteLine("[ 3 ] Ambos");
                Console.Write("Elija una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1" || opcion == "3")
                {
                    string nuevoNombre;
                    int duplicado = 0;

                    do
                    {
                        duplicado = 0;

                        Console.Write("Ingrese el nuevo nombre: ");
                        nuevoNombre = Console.ReadLine();

                        if (nuevoNombre.Trim() == "")
                        {
                            Console.WriteLine("El nombre no puede estar vacío.");
                            continue;
                        }

                        for (int j = 0; j < libros.Length; j++)
                        {
                            if (libros[j].ToLower() == nuevoNombre.ToLower() && j != pos)
                            {
                                duplicado = 1;
                                Console.WriteLine("Ya existe un libro con ese nombre.");
                                break;
                            }
                        }

                    } while (duplicado == 1 || nuevoNombre.Trim() == "");

                    libros[pos] = nuevoNombre;
                }

                if (opcion == "2" || opcion == "3")
                {
                    double nuevoPrecio;
                    bool precioValido = false;

                    do
                    {
                        Console.Write("Ingrese el nuevo precio: ");
                        if (double.TryParse(Console.ReadLine(), out nuevoPrecio) && nuevoPrecio > 0 && nuevoPrecio <= 1000)
                        {
                            precioValido = true;
                            precios[pos] = nuevoPrecio;
                        }

                        else
                        {
                            Console.WriteLine("Precio inválido (debe ser entre 1 y 1000).");
                        }

                    } while (precioValido == false);
                }

                Console.WriteLine("Libro modificado correctamente.");
            }
        }

        public void Eliminar()
        {
            string eli;
            int pos = 0;

            Console.WriteLine("\nIngrese el nombre a eliminar: ");
            eli = Console.ReadLine();

            int indice = -1;

            for (int i = 0; i < libros.Length; i++)
            {
                if (libros[i].ToLower() == eli.ToLower())
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                for (int i = indice; i < libros.Length - 1; i++)
                {
                    libros[i] = libros[i + 1];
                    precios[i] = precios[i + 1];
                }

                Array.Resize(ref libros, libros.Length - 1);
                Array.Resize(ref precios, precios.Length - 1);

                pos--;

                Console.WriteLine("\nLibro eliminado correctamente.");
            }

            else
            {
                Console.WriteLine("\nEl libro no existe, no se puede eliminar.");
            }
        }
    }
}
