using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter _CursoData;
        public CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Business.Entities.Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<Curso> GetPosibles(Materia materia)
        {
            try
            {
                return CursoData.GetPosibles(materia);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<Curso> getCursosDocente(Persona docente)
        {
            try
            {
                return CursoData.getCursosDocente(docente);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);
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
                CursoData.Delete(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void Save(Curso cur)
        {
            try
            {
                CursoData.Save(cur);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public static bool ExisteCurso(int anio, int id_com, int id_mat)
        {
            try
            {
                CursoAdapter ca = new CursoAdapter();
                return ca.ExisteCurso(anio, id_com, id_mat);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
