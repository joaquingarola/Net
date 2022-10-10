using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _DocenteCursoData;

        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }
        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll(Curso cur)
        {
            try
            {
                return DocenteCursoData.GetAll(cur);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                DocenteCursoData.Delete(ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(DocenteCurso dc)
        {
            try
            {
                DocenteCursoData.Save(dc);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public static bool ExisteDocente(int id_doc, int id_cur)
        {
            try
            {
                DocenteCursoAdapter dca = new DocenteCursoAdapter();
                return dca.ExisteDocente(id_doc, id_cur);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
