using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public List<Business.Entities.Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }

        }

        public List<Business.Entities.Materia> GetMateriasPlan(Plan plan)
        {
            try
            {
                return MateriaData.GetMateriasPlan(plan);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<Business.Entities.Materia> GetPosibles(Persona alumno)
        {
            try
            {
                return MateriaData.GetPosibles(alumno.ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public Materia GetOne(int ID)
        {
            try
            {
                return MateriaData.GetOne(ID);
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
                MateriaData.Delete(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }
        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }
    }
}
