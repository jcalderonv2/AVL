using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {

        static Avl avl = new Avl();
        static void Main(string[] args)
        {
            MenuAvl();
        }

        private static void MenuAvl()
        {

            string option;

            do
            {


                Console.WriteLine("\n ---Arbol AVL--- \n");
                Console.WriteLine("\n 1.Agregar dato.");
                Console.WriteLine("\n 2.Mostrar PreOrden.");
                Console.WriteLine("\n 3.Mostrar InOrden.");
                Console.WriteLine("\n 4.Mostrar PostOrden.");
                Console.WriteLine("\n 5.Salir.");
                Console.WriteLine("\n Seleccione una opcion: \n");

                option = Console.ReadLine();
                Console.WriteLine("\n La opcion seleccionada fue: " + option);
                ProcessMainMenu(option);



            } while (option != "5");

        }

        private static void ProcessMainMenu(string option)
        {
            switch (option)
            {

                case "1":

                    InsertArbol();

                    break;

                case "2":

                    PreOrden();

                    break;

                case "3":
                    InOrden();

                    break;

                case "4":
                    PostOrden();

                    break;

                default:

                    Console.WriteLine("\n Opcion invalida.");
                    break;

            }


        }
        private static void InsertArbol()
        {
            NodoAvl nuevo = new NodoAvl();
            Console.WriteLine("\n Digite un numero: \n");
            nuevo.Dato = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            avl.insertar(nuevo.Dato);
            Console.WriteLine("\n El numero " + "'" + nuevo.Dato + "' " + "fue ingresado al arbol AVL.");
        }

        private static void PreOrden()
        {
            
            Console.WriteLine("\n PreOrden: \n");
            avl.PreOrden(avl.obtenerRaiz());
            Console.WriteLine();
        }

        private static void InOrden()
        {
            
            Console.WriteLine("\n InOrden: \n");
            avl.InOrden(avl.obtenerRaiz());
            Console.WriteLine();
        }

        private static void PostOrden()
        {
            
            Console.WriteLine("\n PostOrden: \n");
            avl.PostOrden(avl.obtenerRaiz());
            Console.WriteLine();
        }
    }
}
