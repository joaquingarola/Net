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
            double suma_base, suma_altura;
            suma_base = Base;
            suma_altura = Altura;

            return suma_base * 2 + suma_altura * 2;
        }
    }


    class Cuadrado : Poligono
    {
        public double CalcularPerimetro()
        {
            return Altura + 4;
        }

    }

}
