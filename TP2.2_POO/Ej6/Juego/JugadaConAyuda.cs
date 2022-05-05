using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class JugadaConAyuda : Jugada
    {
        public JugadaConAyuda(int maxNro) : base(maxNro)
        {
        }

        public override int Comparar(int nro)
        {
            int dif = Numero - nro;

            if (dif == 0)
                return 0;
            else if (dif > 10)
                return 1;   
            else if (dif < 10 && dif > 0)
                return 2;  
            else if (dif < 0 && dif > -10)
                return 3;
            else if (dif < -10)
                return 4;

            return 10;
        }
    }
}
