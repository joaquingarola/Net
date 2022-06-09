using System;
using System.Collections.Generic;
using System.Text;


namespace Lab02
{
    class Program
    {

        static void Main(string[] args)
        {
            fileHandler manejadorArch;
            Console.WriteLine("Elija el modo:");
            Console.WriteLine("1 - TXT");
            Console.WriteLine("2 - XML");
            if (Console.ReadLine() == "2")
            {
                manejadorArch = new xmlFileHandler();
            }
            else
            {
                manejadorArch = new txtFileHandler();
            }
            manejadorArch.list();
            menu(manejadorArch);
        }

        static void menu(fileHandler manejadorArch)
        {
            string rta = "";
            do
            {
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("5 - Guardar Cambios");
                Console.WriteLine("6 - Salir");
                rta = Console.ReadLine();
                switch (rta)
                {
                    case "1":
                        manejadorArch.list();
                        break;
                    case "2":
                        manejadorArch.newRow();
                        break;
                    case "3":
                        manejadorArch.editRow();
                        break;
                    case "4":
                        manejadorArch.deleteRow();
                        break;
                    case "5":
                        manejadorArch.applyChanges();
                        break;
                    default:
                        break;
                }
            } while (rta != "6");
        }
    }
}

