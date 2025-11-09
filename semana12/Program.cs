using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conti;
            Libreria l = new Libreria();

            do
            {
                Console.Clear();

                Console.WriteLine(" BIENVENIDOS A TU LIBRERIA ");
                Console.WriteLine("***************************");
                Console.WriteLine("\n  Menú de opciones");
                Console.WriteLine("  [ 1 ] Registrar");
                Console.WriteLine("  [ 2 ] Mostrar");
                Console.WriteLine("  [ 3 ] Modificar");
                Console.WriteLine("  [ 4 ] Eliminar");
                Console.WriteLine("  [ 0 ] Salir\n");
                Console.WriteLine("***************************\n");

                int opc;

                while (true)
                {
                    Console.Write("Ingrese una opción: ");

                    if (int.TryParse(Console.ReadLine(), out opc) & opc >= 0 & opc <= 4)
                        break;

                    else 
                        Console.WriteLine("¡Ingrese una opción valida!\n");
                }

                switch (opc)
                {
                    case 0: return;
                    case 1:  l.Registrar(); break;
                    case 2:  l.Mostrar(); break;
                    case 3:  l.Modificar(); break;
                    case 4:  l.Eliminar(); break;
                }

                while (true)
                {
                    Console.Write("\n¿Desea continuar? (S/N): ");
                    conti = Console.ReadLine().ToLower();

                    if (conti == "s" || conti == "n")
                        break;

                    else 
                        Console.WriteLine("Ingrese solo 's' o 'n' \n");
                }

            } while (conti == "s");

        }
    }
}
