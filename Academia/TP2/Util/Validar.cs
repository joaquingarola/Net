using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Validar
    {
        public static bool isEmpty(string campo)
        {
            if (campo.Trim().Length == 0)
            {
                return true;
            }
            else return false;
        }
    }
}
