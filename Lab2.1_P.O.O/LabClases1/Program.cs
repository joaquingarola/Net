using System;
using Clases; //Referencia No olvidar
namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            A laInstanciaA = new A();


            A app = new A();
            System.Console.WriteLine("El nombre de la instancia es: " + (app.MostrarNombre()));
            System.Console.WriteLine("Ingrese un nuevo nombre de instancia");
            app.NombreInstancia = Console.ReadLine();
            System.Console.WriteLine("El nombre de la instancia es: " + (app.MostrarNombre()));
            System.Console.WriteLine(app.M1());
            System.Console.WriteLine(app.M2());
            System.Console.WriteLine(app.M3());
            Console.ReadKey();
            B pp = new B();
            System.Console.WriteLine(pp.M1());
            System.Console.WriteLine(pp.M2());
            System.Console.WriteLine(pp.M3());
            System.Console.WriteLine(pp.M4());


        }
    }
}
