using System;
using Geometria;


namespace pruebas
{
    class Pruebas
    {
        static void Main(string[] args)
        {

            Circulo c = new Circulo();
            c.Radio = 10.00;

            Console.WriteLine("Radio del circulo: ", c.Radio);
            Console.WriteLine("\n\nPerimetro del ciruclo: ", c.CalcularPerimetro());
            Console.WriteLine("\n\nArea del circulo ", c.CalcularSuperficie());
        }
    }
}
