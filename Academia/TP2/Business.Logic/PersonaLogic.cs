using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Business.Entities.Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public List<Business.Entities.Persona> GetAll(Persona.TipoPersonas tipo)
        {
            try
            {
                return PersonaData.GetAll(tipo);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public Persona GetOne(int ID)
        {
            try
            {
                return PersonaData.GetOne(ID);
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
                PersonaData.Delete(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void Save(Persona pers)
        {
            try
            {
                PersonaData.Save(pers);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public static bool ExisteLegajo(int legajo)
        {
            try
            {
                PersonaAdapter data = new PersonaAdapter();
                return data.ExisteLegajo(legajo);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
