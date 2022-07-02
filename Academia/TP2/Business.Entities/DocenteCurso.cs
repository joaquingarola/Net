using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private Curso _Curso;
        private Persona _Docente;
        private TiposCargos _Cargo;

        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }
        public Persona Docente
        {
            get { return _Docente; }
            set { _Docente = value; }
        }
        public TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public enum TiposCargos
        {
            Practica,
            Teoria,
            Ayudante
        }
    }
}
