using System;

namespace Geometria
{
    class Poligono
    {

        private double m_base;
        private double m_altura;

        public double Altura
        {
            get => m_altura;
            set
            {
                m_altura = value;
            }
        }

        public double Base
        {
            get => m_base;
            set
            {
                m_base = value;
            }
        }


        public void CalcularPerimetro()
        {
            throw new System.NotImplementedException();
        }

        public double CalcularSuperficie()
        {
            return m_altura * m_base;
        }
    }

    class Rectangulo : Poligono
    {
        public double CalcularPerimetro()
        {
            Rectangulo a = new Rectangulo();
            double suma_base, suma_altura;
            suma_base = a.Base;
            suma_altura = a.Altura;

            return suma_base * 2 + suma_altura * 2;
        }
    }

    class Cuadrado : Rectangulo
    {

        public double CalcularPerimetro()
        {
            Cuadrado c = new Cuadrado();
            double perimetro = c.Altura * 4;

            return perimetro;
        }

    }
}
