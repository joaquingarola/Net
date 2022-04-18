using System;

namespace Geometria
{
    public class Circulo
    {
        private int m_radio;

        public int Radio
        {
            get => m_radio;
            set
            {
                m_radio = value;
            }
        }

        public void CalcularPerimetro()
        {
            throw new System.NotImplementedException();
        }

        public void CalcularSuperficie()
        {
            throw new System.NotImplementedException();
        }
    }
}
