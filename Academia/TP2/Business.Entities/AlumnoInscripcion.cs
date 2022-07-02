using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private Condiciones _Condicion;
        private Persona _Alumno;
        private Curso _Curso;
        private int _Nota;

        public enum Condiciones
        {
            Inscripto,
            Cursando,
            Regular,
            Libre,
            Aprobado
        }

        public Condiciones Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        public Persona Alumno
        {
            get { return _Alumno; }
            set { _Alumno = value; }
        }
        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
