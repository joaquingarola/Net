using System;
using Clases;

namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            A instanciaA = new A();
            System.Console.WriteLine("El nombre de la instancia es: " + instanciaA.MostrarNombre());
            A OtrainstanciaA = new A("OtrainstanciaA");
            System.Console.WriteLine("El nombre de la instancia es: " + OtrainstanciaA.MostrarNombre());
            System.Console.WriteLine(instanciaA.M1());
            System.Console.WriteLine(instanciaA.M2());
            System.Console.WriteLine(instanciaA.M3());

            B instanciaB = new B();
            System.Console.WriteLine("El nombre de la instancia es: " + instanciaB.MostrarNombre());
            System.Console.WriteLine(instanciaB.M4());
        }
    }
}
