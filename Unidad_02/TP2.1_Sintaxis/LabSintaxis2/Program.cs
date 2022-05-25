using System;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ej1();
            //Ej2();

        }
        
        static void Ej1()
        {
            string inputTexto;

            Console.WriteLine("Ingrese texto");
            inputTexto = Console.ReadLine();

            if (inputTexto.GetType() == typeof(string))
            {
                menuIf(inputTexto);
            }
            else
            {
                Console.WriteLine("Ingreso inválido");
            }
        }

        static void Ej2()
        {
            string inputTexto;

            Console.WriteLine("Ingrese texto");
            inputTexto = Console.ReadLine();

            if (inputTexto.GetType() == typeof(string))
            {
                menuCase(inputTexto);
            }
            else
            {
                Console.WriteLine("Ingreso inválido");
            }

        }

        static void menuIf(string inputTexto)
        {
            Console.WriteLine("1- Texto en mayúsculas \n2- Texto en minúsculas \n3- Cantidad de caracteres");
            ConsoleKeyInfo opcion = Console.ReadKey();
            Console.WriteLine();
            if (opcion.Key == ConsoleKey.NumPad1 || opcion.Key == ConsoleKey.D1)
                Console.WriteLine(inputTexto.ToUpper());
            else if (opcion.Key == ConsoleKey.NumPad2 || opcion.Key == ConsoleKey.D2)
                Console.WriteLine(inputTexto.ToLower());
            else if (opcion.Key == ConsoleKey.NumPad3 || opcion.Key == ConsoleKey.D3)
                Console.WriteLine("Longitud del texto: " + inputTexto.Length);
            else
                Console.WriteLine("La opción ingresada es incorrecta");
        }

        static void menuCase(string inputTexto)

        {
            Console.WriteLine("1- Texto en mayúsculas \n2- Texto en minúsculas \n3- Cantidad de caracteres");
            ConsoleKeyInfo opcion = Console.ReadKey();
            Console.WriteLine();
            switch (opcion.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine(inputTexto.ToUpper());
                    break;

                case ConsoleKey.NumPad1:
                    Console.WriteLine(inputTexto.ToUpper());
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine(inputTexto.ToLower());
                    break;

                case ConsoleKey.NumPad2:
                    Console.WriteLine(inputTexto.ToLower());
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine(inputTexto.Length);
                    break;

                case ConsoleKey.NumPad3:
                    Console.WriteLine(inputTexto.Length);
                    break;

                default:
                    Console.WriteLine("La opción ingresada es incorrecta");
                    break;
            }
        }
    }
}
