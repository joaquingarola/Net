using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private string _Descripcion;
        private int _AnioCalendario;
        private int _Cupo;
        private Comision _Comision;
        private Materia _Materia;

        public string Descripcion
        {
            get
            {
                return Materia.Descripcion + " - Comisión " + Comision.Descripcion;
            }
        }
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public Comision Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }
        public Materia Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }
    }
}
