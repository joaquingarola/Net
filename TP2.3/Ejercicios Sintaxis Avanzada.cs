using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



////////////////// FALTA TERMINAR



namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] provincias = { "Santa Fe", "Buenos Aires", "Tucuman" };
            List<int> numbers = new List<int>();
            ArrayList Ciudad = new ArrayList();
            var random = new Random();
             

            
            



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



            for (int i = 0; i < 10; i++)
            {
                int randomnumber = random.Next(0, 40);
                numbers.Add(randomnumber);
            }

            var lasProvincias = from p in provincias
                                where p.StartsWith("S") || p.StartsWith("T")
                                select p;

            var theNumbers = from n in numbers
                             where n > 20
                             select n;

            var lasCiudades = from Ciudad c in Ciudad
                              where c.name.ToLower().Contains("ros")
                              select c;
            var LosEmpleados = from Empleado e in Ciudad
                               where e.id = 1
                               orderby sueldo
                               select id, nombre, sueldo;

            foreach (var p in lasProvincias)
            {
                Console.WriteLine(p);
            }

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("------------------------------");

            foreach (var n in theNumbers)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("------------------------------");

            foreach (var c in lasCiudades)
            {
                Console.WriteLine(c.code);
            }
            Console.ReadLine();
        }
        public int Menu()
        {
            List<Empleado> empleados = new List<Empleado>();
            Console.WriteLine("Ingrese 1- Para dar de alta un empleado , 2 - Para ver la lista de empleados");
            String op;
            op = Console.ReadLine();
            int opcion = Int32.Parse(op);
            if (opcion == 1)
            {
                empleados.Add(new Empleado());
               Console.WriteLine("Ingrese sueldo del empleado");
                string s;
                s = Console.ReadLine();
                Console.WriteLine("Ingrese id del empleado");
                string id;
                id = Console.ReadLine();
                Console.WriteLine("Ingrese nombre del empleado");
                string nombre;
                nombre = Console.ReadLine();


            }

            
            return op

        }

    }

    class Ciudad
    {
        string nombre;
        int codigo_postal;

        public string name { get { return nombre; } set { nombre = value; } }
        public int code { get { return codigo_postal; } set { codigo_postal = value; } }
    }
    class Empleado
    {
        int id;
        string nombre;
        decimal sueldo;

        

        public int idE { get { return id; } set { id = value; } }
        public string nombreE { get { return nombre; } set { nombre = value; } }
        public decimal sueldoE { get { return sueldo; } set { sueldo = value; } }


    }
}
