using System;

namespace Clases
{
    public class A
    {
        String nombreInstancia;
        public String NombreInstancia{
            get;
            set;
        }
        public A()
        {
            nombreInstancia = "Instancia sin nombre";
        }
        public A(String s)
        {
            nombreInstancia = s;
        }
        public String MostrarNombre()
        {
            return nombreInstancia;

        }
        public string M1()
        {
            return "El método m1 fue invocado";
        }
        public string M2()
        {
            return "El método m2 fue invocado";
        }
        public string M3()
        {
            return "El método m3 fue invocado";
        }
    }
}
