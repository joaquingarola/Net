using System;

namespace LabSintaxis4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ej01();
            //ej02();
            //ej03();
            //ej04();
        }
        static void ej01()
        {
            Console.WriteLine("Ingrese el primer valor:");
            int valor1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo valor:");
            int valor2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("El resultado de la suma de " + valor1 + " y " + valor2 + " es " + (valor1 + valor2));
        }
        static void ej02()
        {
            Console.WriteLine("Ingrese año a evaluar");
            int año = Int32.Parse(Console.ReadLine());
            if(año%4 == 0)
            {
                if(año%100 == 0)
                {
                    if(año%400 == 0)
                        Console.WriteLine("El año es bisiesto");
                    else
                        Console.WriteLine("El año no es bisiesto");
                }
                else
                    Console.WriteLine("El año es bisiesto");
            }
            else
                Console.WriteLine("El año no es bisiesto");
        }
        static void ej03()
        {
            Console.WriteLine("Sucesión de Fibonacci");
            Console.WriteLine("Cuantos elementos desea calcular?");
            int n = Int32.Parse(Console.ReadLine());
            int a = 0, b = 1, c;
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                c = a + b;
                a = b;
                b = c;
            }
        }
        static void ej04()
        {
            Console.WriteLine("Números pares entre 1 y 100");
            for(int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
