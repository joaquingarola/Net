using System;

namespace Clases
{
    public class A
    {
        public void F() { Console.WriteLine("A.F"); }
        public virtual void G() { Console.WriteLine("A.G"); }
    }

    public class B : A
    {
        public void F() { Console.WriteLine("B.F"); }
        public void G() { Console.WriteLine("B.G"); }
    }
}
