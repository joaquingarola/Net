using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter m_UsuarioData;

        public UsuarioAdapter UsuarioData
        {
            get { return m_UsuarioData; }
            set { m_UsuarioData = value; }
        }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public Usuario GetOne(string usuario, string clave)
        {
            try
            {
                return UsuarioData.GetOne(usuario, clave);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
