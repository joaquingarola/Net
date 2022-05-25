using System;

namespace Geometria
{
    public class Circulo
    {
        ///private double m_radio;

       /*public double Radio
        {
            get => m_radio;
            set
            {
                m_radio = value;
            }
        } */

        public double Radio { get; set; }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }

        public double CalcularSuperficie()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }

    }
}
