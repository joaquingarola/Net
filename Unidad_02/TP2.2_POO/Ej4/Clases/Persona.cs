using System;

namespace Clases
{
    public class Persona
    {
        private String nombre, apellido, dni;
        private int edad;

        public Persona(String nombre, String apellido, String dni, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.edad = edad;

            Console.WriteLine("Objeto creado con éxito");
        }

        ~Persona()
        {
            Console.WriteLine("Objeto destruido con éxito");
        }

        public String GetNombre()
        {
            return nombre;
        }

        public String GetApellido()
        {
            return apellido;
        }

        public String GetDni()
        {
            return dni;
        }

        public int GetEdad()
        {
            return edad;
        }

        public String GetFullName()
        {
            return nombre + " " + apellido;
        }

        public int GetAge()
        {
            return edad; //????
        }
    }

}
