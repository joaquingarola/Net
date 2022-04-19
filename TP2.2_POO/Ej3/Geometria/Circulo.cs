using System;

namespace Geometria
{
    public class Circulo
    {
        private double m_radio;

        public double Radio
        {
            get => m_radio;
            set
            {
                m_radio = value;
            }
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * m_radio;
        }

        public double CalcularSuperficie()
        {
            return Math.PI * Math.Pow(m_radio, 2);
        }
    }
}
