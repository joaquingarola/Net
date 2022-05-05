using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Jugada
    {
        private bool _adivino;
        private int _numero;
        private int _intentos;

        public bool Adivino
        {
            get
            {
                return _adivino;
            }
            set
            {
                _adivino = value;
            }
        }

        public int Intentos
        {
            get
            {
                return _intentos;
            }
            set
            {
                _intentos = value;
            }
        }

        public int Numero
        {
            get 
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            Numero = rnd.Next(maxNumero);
            Intentos = 0;
            Adivino = false;
        }

        public bool Comparar(int nro)
        {
            if (nro == Numero)
                return true;
            else
                return false;
        }

    }
}
