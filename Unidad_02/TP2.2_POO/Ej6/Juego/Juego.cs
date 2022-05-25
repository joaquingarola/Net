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

            Console.WriteLine("Deberá adivinar el número (entre 0 y 50) para ganar. Tendrá como máximo 15 intentos \n" 
                                + "Se le proporcionará una ayuda que indicará si el número es mayor o menor, " 
                                + "y si está lejos o cerca");
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
            JugadaConAyuda j = new JugadaConAyuda(50);
            Console.Clear();
            while (j.Intentos < 15 && !j.Adivino)
            {
                switch (j.Comparar(PreguntarNumero()))
                {
                    case 0:
                        j.Adivino = true;
                        j.Intentos++;
                        Console.WriteLine("Correcto!");
                        break;
                    case 1:
                        j.Intentos++;
                        Console.WriteLine($"Incorrecto. El número es mayor y está lejos. Intentos restantes {15 - j.Intentos}");
                        break;
                    case 2:
                        j.Intentos++;
                        Console.WriteLine($"Incorrecto. El número es mayor y está cerca. Intentos restantes {15 - j.Intentos}");
                        break;
                    case 3:
                        j.Intentos++;
                        Console.WriteLine($"Incorrecto. El número es menor y está cerca. Intentos restantes {15 - j.Intentos}");
                        break;
                    case 4:
                        j.Intentos++;
                        Console.WriteLine($"Incorrecto. El número es menor y está lejos . Intentos restantes {15 - j.Intentos}");
                        break;
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
            Console.WriteLine("Ingrese un número entre 0 y 50");
            int nro = int.Parse(Console.ReadLine());
            while (nro < 0 || nro > 50)
            {
                Console.WriteLine("El número debe estar entre 0 y 50");
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
