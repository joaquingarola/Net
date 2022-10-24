using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Business.Entities.Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<Business.Entities.Comision> GetComisionesPlan(Plan plan)
        {
            try
            {
                return ComisionData.GetComisionesPlan(plan);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public Comision GetOne(int ID)
        {
            try
            {
                return ComisionData.GetOne(ID);
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
                ComisionData.Delete(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void Save(Comision comi)
        {
            try
            {
                ComisionData.Save(comi);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }
    }
}
