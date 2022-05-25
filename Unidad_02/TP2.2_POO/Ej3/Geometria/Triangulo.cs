using System;

namespace Geometria
{
    class Triangulo
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
            return m_altura * m_altura;
        }
    }
}
