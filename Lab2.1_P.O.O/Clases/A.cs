using System;

namespace Clases
{
    public class A
    {


        public String NombreInstancia { get; set; }


        public A() {
            NombreInstancia = "Instancia sin nombre";
        }
        public A(String s)
        {
            NombreInstancia = s;

        }
        public String MostrarNombre()
        {
            return NombreInstancia;

        }
        public string M1()
        {
            String p;
            return p = "el metodo m1 fue invocado";
        }
        public string M2()
        {
            String p;
            return p = "el metodo m2 fue invocado";
        }
        public string M3()
        {
            String p;
            return p = "el metodo m3 fue invocado";
        }
    }
}


