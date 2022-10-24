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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Comision = new Comision();
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Materia = new Materia();
                    cur.Materia.ID = (int)drCursos["id_materia"];
                    cursos.Add(cur);
                }
                drCursos.Close();
                foreach (Curso cur in cursos)
                {
                    MateriaAdapter ma = new MateriaAdapter();
                    cur.Materia = ma.GetOne(cur.Materia.ID);
                    ComisionAdapter ca = new ComisionAdapter();
                    cur.Comision = ca.GetOne(cur.Comision.ID);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<Curso> GetPosibles(Materia materia)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdSELECT = new SqlCommand("SELECT id_curso, id_comision FROM cursos " +
                    "where id_materia=@id and anio_calendario=@anio and cupo > 0", sqlConn);
                cmdSELECT.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSELECT.Parameters.Add("@anio", SqlDbType.Int).Value = DateTime.Today.Year;
                SqlDataReader reader = cmdSELECT.ExecuteReader();
                while (reader.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)reader["id_curso"];
                    cur.Materia = materia;
                    cur.Comision = new Comision();
                    cur.Comision.ID = (int)reader["id_comision"];
                    cursos.Add(cur);
                }
                reader.Close();
                foreach (Curso cur in cursos)
                {
                    ComisionAdapter ca = new ComisionAdapter();
                    cur.Comision = ca.GetOne(cur.Comision.ID);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron obtener los datos de los posibles cursos", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<Curso> getCursosDocente(Persona docente)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdSELECT = new SqlCommand("SELECT cur.id_curso, id_materia, id_comision, anio_calendario" +
                    " FROM cursos cur INNER JOIN docentes_cursos doc ON doc.id_curso=cur.id_curso" +
                    " where id_docente=@id", sqlConn);
                cmdSELECT.Parameters.Add("@id", SqlDbType.Int).Value = docente.ID;
                SqlDataReader reader = cmdSELECT.ExecuteReader();
                while (reader.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)reader["id_curso"];
                    cur.Comision = new Comision();
                    cur.Comision.ID = (int)reader["id_comision"];
                    cur.Materia = new Materia();
                    cur.Materia.ID = (int)reader["id_materia"];
                    cur.AnioCalendario = (int)reader["anio_calendario"];
                    cursos.Add(cur);
                }
                reader.Close();
                foreach (Curso cur in cursos)
                {
                    MateriaAdapter ma = new MateriaAdapter();
                    cur.Materia = ma.GetOne(cur.Materia.ID);
                    ComisionAdapter ca = new ComisionAdapter();
                    cur.Comision = ca.GetOne(cur.Comision.ID);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar los curso del docente", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Comision = new Comision();
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Materia = new Materia();
                    cur.Materia.ID = (int)drCursos["id_materia"];
                }
                drCursos.Close();
                MateriaAdapter ma = new MateriaAdapter();
                cur.Materia = ma.GetOne(cur.Materia.ID);
                ComisionAdapter ca = new ComisionAdapter();
                cur.Comision = ca.GetOne(cur.Comision.ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public bool ExisteCurso(int anio, int id_com, int id_mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where anio_calendario=@anio and id_comision=@id_com and id_materia=@id_mat", sqlConn);
                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmdCursos.Parameters.Add("@id_com", SqlDbType.Int).Value = id_com;
                cmdCursos.Parameters.Add("@id_mat", SqlDbType.Int).Value = id_mat;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    return true;
                }
                else return false;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al verificar curso", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET id_materia=@id_materia,anio_calendario=@anio_calendario," +
                    "cupo=@cupo,id_comision=@id_comision " +
                    "WHERE id_curso=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.Materia.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.Comision.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into cursos(id_materia,anio_calendario,cupo,id_comision)" +
                    "values(@id_materia,@anio_calendario,@cupo,@id_comision) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.Materia.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.Comision.ID;
                curso.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
