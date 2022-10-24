using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    if ((int)drPersonas["tipo_persona"] != 2)
                    {
                        Persona psa = new Persona();
                        psa.ID = (int)drPersonas["id_persona"];
                        psa.Nombre = (string)drPersonas["nombre"];
                        psa.Apellido = (string)drPersonas["apellido"];
                        psa.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        psa.Direccion = (string)drPersonas["direccion"];
                        psa.Telefono = (string)drPersonas["telefono"];
                        psa.Email = (string)drPersonas["email"];
                        psa.Legajo = (int)drPersonas["legajo"];
                        psa.Plan = new Plan();
                        psa.Plan.ID = (int)drPersonas["id_plan"];
                        switch ((int)drPersonas["tipo_persona"])
                        {
                            case 0:
                                psa.TipoPersona = Persona.TipoPersonas.Alumno;
                                break;

                            case 1:
                                psa.TipoPersona = Persona.TipoPersonas.Profesor;
                                break;
                        }
                        personas.Add(psa);
                    }
                }
                drPersonas.Close();
                foreach (Persona p in personas)
                {
                    if (p.TipoPersona != Persona.TipoPersonas.Administrador)
                    {
                        PlanAdapter pa = new PlanAdapter();
                        p.Plan = pa.GetOne(p.Plan.ID);
                    }
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public List<Persona> GetAll(Persona.TipoPersonas tipo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona=@tipo", sqlConn);
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    if ((int)drPersonas["tipo_persona"] != 2)
                    {
                        Persona psa = new Persona();
                        psa.ID = (int)drPersonas["id_persona"];
                        psa.Nombre = (string)drPersonas["nombre"];
                        psa.Apellido = (string)drPersonas["apellido"];
                        psa.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        psa.Direccion = (string)drPersonas["direccion"];
                        psa.Telefono = (string)drPersonas["telefono"];
                        psa.Email = (string)drPersonas["email"];
                        psa.Legajo = (int)drPersonas["legajo"];
                        psa.Plan = new Plan();
                        psa.Plan.ID = (int)drPersonas["id_plan"];
                        switch ((int)drPersonas["tipo_persona"])
                        {
                            case 0:
                                psa.TipoPersona = Persona.TipoPersonas.Alumno;
                                break;

                            case 1:
                                psa.TipoPersona = Persona.TipoPersonas.Profesor;
                                break;
                        }
                        personas.Add(psa);
                    }
                }
                drPersonas.Close();
                foreach (Persona p in personas)
                {
                    PlanAdapter pa = new PlanAdapter();
                    p.Plan = pa.GetOne(p.Plan.ID);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public List<Persona> GetAll(Persona.TipoPersonas tipo, int id_plan)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona=@tipo and id_plan = @id", sqlConn);
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = id_plan;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    if ((int)drPersonas["tipo_persona"] != 2)
                    {
                        Persona psa = new Persona();
                        psa.ID = (int)drPersonas["id_persona"];
                        psa.Nombre = (string)drPersonas["nombre"];
                        psa.Apellido = (string)drPersonas["apellido"];
                        psa.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        psa.Direccion = (string)drPersonas["direccion"];
                        psa.Telefono = (string)drPersonas["telefono"];
                        psa.Email = (string)drPersonas["email"];
                        psa.Legajo = (int)drPersonas["legajo"];
                        psa.Plan = new Plan();
                        psa.Plan.ID = (int)drPersonas["id_plan"];
                        switch ((int)drPersonas["tipo_persona"])
                        {
                            case 0:
                                psa.TipoPersona = Persona.TipoPersonas.Alumno;
                                break;

                            case 1:
                                psa.TipoPersona = Persona.TipoPersonas.Profesor;
                                break;
                        }
                        personas.Add(psa);
                    }
                }
                drPersonas.Close();
                foreach (Persona p in personas)
                {
                    PlanAdapter pa = new PlanAdapter();
                    p.Plan = pa.GetOne(p.Plan.ID);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            Persona psa = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    psa.ID = (int)drPersonas["id_persona"];
                    psa.Nombre = (string)drPersonas["nombre"];
                    psa.Apellido = (string)drPersonas["apellido"];
                    psa.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    psa.Direccion = (string)drPersonas["direccion"];
                    psa.Telefono = (string)drPersonas["telefono"];
                    psa.Email = (string)drPersonas["email"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 0:
                            psa.TipoPersona = Persona.TipoPersonas.Alumno;
                            psa.Legajo = (int)drPersonas["legajo"];
                            psa.Plan = new Plan();
                            psa.Plan.ID = (int)drPersonas["id_plan"];
                            break;

                        case 1:
                            psa.TipoPersona = Persona.TipoPersonas.Profesor;
                            psa.Legajo = (int)drPersonas["legajo"];
                            psa.Plan = new Plan();
                            psa.Plan.ID = (int)drPersonas["id_plan"];
                            break;

                        case 2:
                            psa.TipoPersona = Persona.TipoPersonas.Administrador;
                            break;
                    }
                }
                drPersonas.Close();
                if (psa.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    PlanAdapter pa = new PlanAdapter();
                    psa.Plan = pa.GetOne(psa.Plan.ID);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return psa;
        }

        public bool ExisteLegajo(int legajo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where legajo=@leg", sqlConn);
                cmdPersonas.Parameters.Add("@leg", SqlDbType.Int).Value = legajo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    return true;
                }
                else return false;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al verificar legajo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE personas SET fecha_nac=@fecha_nac,legajo=@legajo,id_plan=@id_plan,tipo_persona=@tipo_persona," +
                "direccion=@direccion,nombre=@nombre,apellido=@apellido,email=@email,telefono=@telefono " +
                "WHERE id_persona=@id", sqlConn);

                SqlCommand cmdSave2 = new SqlCommand(
                "UPDATE personas SET fecha_nac=@fecha_nac,legajo=@legajo,id_plan=@id_plan,tipo_persona=@tipo_persona," +
                "direccion=@direccion,nombre=@nombre,apellido=@apellido,email=@email,telefono=@telefono " +
                "WHERE id_persona=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;

                cmdSave2.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave2.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave2.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave2.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave2.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave2.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave2.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                switch (persona.TipoPersona)
                {
                    case Persona.TipoPersonas.Alumno:
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 0;
                        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
                        break;

                    case Persona.TipoPersonas.Profesor:
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;
                        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
                        break;

                    case Persona.TipoPersonas.Administrador:
                        cmdSave2.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave2.ExecuteNonQuery());
                        break;
                }
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into personas(fecha_nac,legajo,id_plan,nombre,apellido,email,tipo_persona,telefono,direccion)" +
                "values(@fecha_nac,@legajo,@id_plan,@nombre,@apellido,@email,@tipo_persona,@telefono,@direccion) " +
                "select @@identity"
                , sqlConn);

                SqlCommand cmdSave2 = new SqlCommand(
                "insert into personas(fecha_nac,legajo,nombre,apellido,email,tipo_persona,telefono,direccion)" +
                "values(@fecha_nac,@legajo,@nombre,@apellido,@email,@tipo_persona,@telefono,@direccion) " +
                "select @@identity"
                , sqlConn);

                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;

                cmdSave2.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave2.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave2.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave2.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave2.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave2.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave2.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                switch (persona.TipoPersona)
                {
                    case Persona.TipoPersonas.Alumno:
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 0;
                        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
                        break;

                    case Persona.TipoPersonas.Profesor:
                        cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;
                        cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
                        break;

                    case Persona.TipoPersonas.Administrador:
                        cmdSave2.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;
                        persona.ID = Decimal.ToInt32((Decimal)cmdSave2.ExecuteNonQuery());
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar persona", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {

            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
