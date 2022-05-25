using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private string _Telefono;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private TiposPersonas _TipoPersona;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        public TiposPersonas TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        public enum TiposPersonas
        {
            Docente,
            Alumno
        }
    }
}
