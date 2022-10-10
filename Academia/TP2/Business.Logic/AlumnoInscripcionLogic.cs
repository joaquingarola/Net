using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        AlumnoInscripcionAdapter aiDatos;

        public AlumnoInscripcionLogic()
        {
            aiDatos = new AlumnoInscripcionAdapter();
        }

        public void Save(AlumnoInscripcion ai)
        {
            try
            {
                aiDatos.Save(ai);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(Persona alu)
        {
            try
            {
                return aiDatos.GetInscripcionesAlumno(alu);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            try
            {
                return aiDatos.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void confirmarInscripciones(Persona alu)
        {
            try
            {
                List<AlumnoInscripcion> inscripciones = aiDatos.GetInscripcionesAlumno(alu);
                foreach (AlumnoInscripcion insc in inscripciones)
                {
                    AlumnoInscripcion aluInsc = aiDatos.GetOne(insc.ID);
                    aluInsc.Condicion = AlumnoInscripcion.Condiciones.Cursando;
                    aluInsc.State = BusinessEntity.States.Modified;
                    this.Save(aluInsc);
                }
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<AlumnoInscripcion> getInscripcionesCurso(Curso cur)
        {
            try
            {
                return aiDatos.getInscripcionesCurso(cur);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                aiDatos.Delete(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }
    }
}
