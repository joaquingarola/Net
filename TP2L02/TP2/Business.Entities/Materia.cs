using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private int _IDPlan;
        private int _HSSemanales;
        private int _HSTotales;
        private string _Descripcion;

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }
        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
