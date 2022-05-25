using System;
using Clases;

namespace Clases
{
    public class Juego
    {
        int[] record = { 50, 50, 50};
        public void ComenzarJuego()
        {
            int opc = 10;

            Console.WriteLine("Deberá adivinar el número (entre 0 y 20) para ganar. Tendrá como máximo 15 intentos");
            Console.Write("Presione cualquier tecla para seguir..");
            Console.ReadLine();

            Console.Clear();
            while (opc != 3)
            {
                Console.WriteLine("1- Jugar \n"
                                   + "2- Ver records \n" 
                                   + "3- Salir");

                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Jugar();
                        break;
                    case 2:
                        ListarRecords();
                        break;
                    case 3:
                        Console.WriteLine("Adiós!");
                        break;
                }
            }
            
        }

        private void Jugar()
        {
            Jugada j = new Jugada(20);
            Console.Clear();
            while (j.Intentos < 15 && !j.Adivino)
            {
                if (j.Comparar(PreguntarNumero()))
                {
                    j.Adivino = true;
                    j.Intentos++;
                    Console.WriteLine("Correcto!");
                }
                else
                {
                    j.Intentos++;
                    Console.WriteLine($"Incorrecto. Intentos restantes {15 - j.Intentos}");
                }
            }
            if (j.Adivino)
            {
                Console.WriteLine($"Felicidades, adivino el número en : {j.Intentos} intentos");
                CompararRecord(j.Intentos);
            } 
            else
                Console.WriteLine($"Ya no le quedan más intentos. El número era {j.Numero}");
            Console.ReadLine();
            Console.Clear();
        }

        private int PreguntarNumero()
        {
            Console.WriteLine("Ingrese un número entre 0 y 20");
            int nro = int.Parse(Console.ReadLine());
            while (nro < 0 || nro > 20)
            {
                Console.WriteLine("El número debe estar entre 0 y 20");
                nro = int.Parse(Console.ReadLine());
            }

            return nro;
        }

        private void CompararRecord(int intentos)
        {
            for(int i = 0; i < record.Length; i++)
            {
                if(intentos < record[i])
                {
                    if(i == 0)
                    {
                        int aux = record[i];
                        int aux2 = record[i + 1];
                        record[i + 1] = aux;
                        record[i + 2] = aux2;
                    }
                    else if(i == 1)
                    {
                        int aux = record[i];
                        record[i + 1] = aux;
                    }
                    record[i] = intentos;
                    Console.WriteLine("Ha establecido un nuevo récord \n" +
                                        $"Su jugada se encuentra en el top {i+1}" );
                    break;
                }
            }
        }

        private void ListarRecords()
        {
            string valor;
            Console.Clear();
            Console.WriteLine("Records");
            for (int i = 1; i <= record.Length; i++)
            {
                if (record[i - 1] > 15)
                    valor = "-";
                else
                    valor = record[i - 1].ToString();

                Console.WriteLine($"{i}- {valor}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
