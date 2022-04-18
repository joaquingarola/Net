using System;

namespace Clases
{
    public class B : A
    {
        String nombreInstancia;
        public String M4()
        {
            return "Metodo del hijo invocado";

        }
        public B() : base("Instancia de B")
        {
        }
    }
}
