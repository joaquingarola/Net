using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _IdUsuario;
        private int _IdModulo;
        private bool _PermiteAlta;
        private bool _PermiteBaja;
        private bool _PermiteModificacion;
        private bool _PermiteConsulta;

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public int IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        public bool PermiteAlta
        {
            get { return _PermiteAlta; }
            set { _PermiteAlta = value; }
        }
        public bool PermiteBaja
        {
            get { return _PermiteBaja; }
            set { _PermiteBaja = value; }
        }
        public bool PermiteModificacion
        {
            get { return _PermiteModificacion; }
            set { _PermiteModificacion = value; }
        }
        public bool PermiteConsulta
        {
            get { return _PermiteConsulta; }
            set { _PermiteConsulta = value; }
        }

    }
}
