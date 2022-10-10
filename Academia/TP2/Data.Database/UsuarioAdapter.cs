using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona = new Persona();
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
                PersonaAdapter PersonaData = new PersonaAdapter();
                foreach (Usuario usr in usuarios)
                {
                    usr.Persona = PersonaData.GetOne(usr.Persona.ID);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar la lista de usuarios", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona = new Persona();
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
                PersonaAdapter PersonaData = new PersonaAdapter();
                usr.Persona = PersonaData.GetOne(usr.Persona.ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public Business.Entities.Usuario GetOne(string usuario, string clave)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select id_usuario, id_persona, nombre_usuario, clave " +
                    "from usuarios where nombre_usuario=@nombre_usuario and clave=@clave and habilitado=1", sqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Persona = new Persona();
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                }
                else return new Usuario();
                drUsuarios.Close();
                PersonaAdapter PersonaData = new PersonaAdapter();
                usr.Persona = PersonaData.GetOne(usr.Persona.ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE usuarios SET nombre_usuario=@nombre_usuario,clave=@clave," +
                "habilitado=@habilitado,id_persona=@id_persona " +
                "WHERE id_usuario=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios(nombre_usuario,clave,habilitado,id_persona)" +
                "values(@nombre_usuario,@clave,@habilitado,@id_persona) " +
                "select @@identity"
                , sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                usuario.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
