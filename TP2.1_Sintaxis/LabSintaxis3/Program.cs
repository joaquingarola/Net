using System;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] ArrayString = new String[5];
            int cantIteraciones = 5;
            for (int i = 0; i < cantIteraciones; i++)
            { 
                Console.WriteLine("Ingrese texto numero " + i );
                ArrayString[i] = Console.ReadLine();
            }
            for (int i = cantIteraciones-1; i >= 0; i--)
            {
                Console.WriteLine(ArrayString[i]);
            }

        }
    }
}
