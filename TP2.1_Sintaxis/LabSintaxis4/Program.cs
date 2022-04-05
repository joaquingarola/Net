using System;

namespace LabSintaxis4
{
    class Program
    {
        static void Main(string[] args)
        {
            ej01();
        }
        static void ej01()
        {
            Console.WriteLine("Ingrese el primer valor");
            int valor1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo valor");
            int valor2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("El resultado de la suma de " + valor1 + " y " + valor2 + " es " + (valor1 + valor2));
        }
    }
}
