using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            int opc = 0;

            while (opc != 5)
            {
                Console.WriteLine("1- Ejercicio 1 \n" +
                                    "2- Ejercicio 2 \n" +
                                    "3- Ejercicio 3 \n" +
                                    "4- Ejercicio 4 \n" +
                                    "5- Salir");
                Console.WriteLine();
                opc = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (opc)
                {
                    case 1:
                        Ejercicio1();
                        break;
                    case 2:
                        Ejercicio2();
                        break;
                    case 3:
                        Ejercicio3();
                        break;
                    case 4:
                        Ejercicio4();
                        break;
                    case 5:
                        Console.WriteLine("Adios!");
                        break;
                }
            }
        }

        static void Ejercicio1()
        {
            string[] provincias = { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego", "Tucuman" };

            var lasProvincias = from p in provincias
                                where p.StartsWith("S") || p.StartsWith("T")
                                select p;

            Console.WriteLine("Provincias que empiezan con S o T");
            foreach (var p in lasProvincias)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void Ejercicio2()
        {
            List<int> numbers = new List<int>();
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int randomnumber = random.Next(0, 40);
                numbers.Add(randomnumber);
            }

            var theNumbers = from n in numbers
                             where n > 20
                             select n;

            Console.WriteLine("Lista de números");
            foreach (var n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Números mayores a 20");
            foreach (var n in theNumbers)
            {
                Console.Write(n + " ");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void Ejercicio3()
        {
            ArrayList Ciudad = new ArrayList();

            Ciudad c1 = new Ciudad { name = "Rosario", code = 2000 };
            Ciudad.Add(c1);
            Ciudad c2 = new Ciudad { name = "El Trebol", code = 2535 };
            Ciudad.Add(c2);
            Ciudad c3 = new Ciudad { name = "Casilda", code = 2170 };
            Ciudad.Add(c3);
            Ciudad c4 = new Ciudad { name = "Santa Fe", code = 3000 };
            Ciudad.Add(c4);
            Ciudad c5 = new Ciudad { name = "Rafaela", code = 2300 };
            Ciudad.Add(c5);
            Ciudad c6 = new Ciudad { name = "Armstrong", code = 2508 };
            Ciudad.Add(c6);
            Ciudad c7 = new Ciudad { name = "Coronda", code = 2240 };
            Ciudad.Add(c7);
            Ciudad c8 = new Ciudad { name = "Firmat", code = 2630 };
            Ciudad.Add(c8);
            Ciudad c9 = new Ciudad { name = "Las Parejas", code = 2505 };
            Ciudad.Add(c9);
            Ciudad c10 = new Ciudad { name = "San Jorge", code = 2451 };
            Ciudad.Add(c10);
            Ciudad c11 = new Ciudad { name = "San Geronimo", code = 2136 };
            Ciudad.Add(c11);
            Ciudad c12 = new Ciudad { name = "Sunchales", code = 2322 };
            Ciudad.Add(c12);

            Console.WriteLine("Ingrese una expresión de 3 caracteres");
            String exp = Console.ReadLine();

            var lasCiudades = from Ciudad c in Ciudad
                              where c.name.ToLower().Contains(exp.ToLower())
                              select c;

            if (lasCiudades.Count() > 0)
            {
                foreach (var c in lasCiudades)
                {
                    Console.WriteLine(c.name + ", " + c.code);
                }
            }
            else
            {
                Console.WriteLine("Ninguna ciudad coincide con la expresión ingresada");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void Ejercicio4()
        {
            List<Empleado> empleados = new List<Empleado>();
            Empleado e1 = new Empleado(1, "Joaquin", 22500);
            Empleado e2 = new Empleado(2, "Manuel", 17500);
            Empleado e3 = new Empleado(3, "Andres", 20000);
            Empleado e4 = new Empleado(4, "Lucia", 25000);
            Empleado e5 = new Empleado(5, "Sofia", 15000);
            empleados.Add(e1);
            empleados.Add(e2);
            empleados.Add(e3);
            empleados.Add(e4);
            empleados.Add(e5);

            int op = 0;

            Console.Clear();

            while (op != 4)
            {
                Console.WriteLine("1- Agregar empleado \n" +
                                    "2- Listar empleados (sueldo asc) \n" +
                                    "3- Listar empleados (sueldo desc) \n" +
                                    "4- Salir");
                Console.WriteLine();
                op = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Ingrese id del empleado");
                        int i = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese nombre del empleado");
                        string n = Console.ReadLine();
                        Console.WriteLine("Ingrese sueldo del empleado");
                        decimal s = Decimal.Parse(Console.ReadLine());

                        Empleado e = new Empleado(i, n, s);
                        empleados.Add(e);

                        Console.WriteLine("Empleado agregado con éxito");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        var losEmpleadosAsc = from emp in empleados
                                           orderby emp.sueldo ascending
                                           select emp;

                        foreach (var emp in losEmpleadosAsc)
                        {
                            emp.mostrar();
                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        var losEmpleadosDesc = from emp in empleados
                                               orderby emp.sueldo descending
                                               select emp;

                        foreach (var emp in losEmpleadosDesc)
                        {
                            emp.mostrar();
                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        break;
                }
            }

        }

    }
    class Empleado
    {
        public int id;
        public String nombre;
        public decimal sueldo;

        public Empleado(int i, String n, decimal s)
        {
            id = i;
            nombre = n;
            sueldo = s;
        }
        public void mostrar()
        {
            Console.WriteLine(id + " " + nombre + " $" + sueldo);
        }
    }

    class Ciudad
    {
        String nombre;
        int codigo_postal;

        public String name { get { return nombre; } set { nombre = value; } }
        public int code { get { return codigo_postal; } set { codigo_postal = value; } }
    }
}
