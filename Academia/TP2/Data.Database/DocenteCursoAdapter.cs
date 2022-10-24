using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll(Curso cur)
        {
            List<DocenteCurso> docentesCurso = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdSELECT = new SqlCommand("select * from docentes_cursos where id_curso=@id", sqlConn);
                cmdSELECT.Parameters.Add("@id", SqlDbType.Int).Value = cur.ID;
                SqlDataReader reader = cmdSELECT.ExecuteReader();
                while (reader.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)reader["id_dictado"];
                    switch (reader["cargo"])
                    {
                        case (0):
                            dc.Cargo = DocenteCurso.TipoCargos.Profesor;
                            break;

                        case (1):
                            dc.Cargo = DocenteCurso.TipoCargos.Auxiliar;
                            break;
                    }
                    dc.Docente = new Persona();
                    dc.Docente.ID = (int)reader["id_docente"];
                    dc.Curso = new Curso();
                    dc.Curso.ID = (int)reader["id_curso"];
                    docentesCurso.Add(dc);
                }
                reader.Close();
                foreach (DocenteCurso dc in docentesCurso)
                {
                    PersonaAdapter pl = new PersonaAdapter();
                    dc.Docente = pl.GetOne(dc.Docente.ID);
                    CursoAdapter cl = new CursoAdapter();
                    dc.Curso = cl.GetOne(dc.Curso.ID);
                }
            }
            catch
            {
                throw new Exception("Error al recuperar docentes");
            }
            finally
            {
                this.CloseConnection();
            }
            return docentesCurso;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdSELECT = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmdSELECT.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader reader = cmdSELECT.ExecuteReader();
                while (reader.Read())
                {
                    docenteCurso.ID = (int)reader["id_dictado"];
                    switch (reader["cargo"])
                    {
                        case (0):
                            docenteCurso.Cargo = DocenteCurso.TipoCargos.Profesor;
                            break;

                        case (1):
                            docenteCurso.Cargo = DocenteCurso.TipoCargos.Auxiliar;
                            break;
                    }
                    docenteCurso.Docente = new Persona();
                    docenteCurso.Docente.ID = (int)reader["id_docente"];
                    docenteCurso.Curso = new Curso();
                    docenteCurso.Curso.ID = (int)reader["id_curso"];
                }
                reader.Close();
                PersonaAdapter pl = new PersonaAdapter();
                docenteCurso.Docente = pl.GetOne(docenteCurso.Docente.ID);
                CursoAdapter cl = new CursoAdapter();
                docenteCurso.Curso = cl.GetOne(docenteCurso.Curso.ID);

            }
            catch
            {
                throw new Exception("Error al recuperar docentes");
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCurso;
        }

        public bool ExisteDocente(int id_doc, int id_cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCurso = new SqlCommand("select * from docentes_cursos where id_curso=@id_cur and id_docente=@id_doc", sqlConn);
                cmdDocentesCurso.Parameters.Add("@id_cur", SqlDbType.Int).Value = id_cur;
                cmdDocentesCurso.Parameters.Add("@id_doc", SqlDbType.Int).Value = id_doc;
                SqlDataReader drDocentesCurso = cmdDocentesCurso.ExecuteReader();
                if (drDocentesCurso.Read())
                {
                    return true;
                }
                else return false;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al verificar si el docente ya participa del curso", Ex);
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
                    new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar cargo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into docentes_cursos(cargo,id_curso,id_docente)" +
                    "values(@cargo,@id_curso,@id_docente) " + "select @@identity", sqlConn);
                switch (dc.Cargo)
                {
                    case (DocenteCurso.TipoCargos.Profesor):
                        cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = 0;
                        break;

                    case (DocenteCurso.TipoCargos.Auxiliar):
                        cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = 1;
                        break;

                }
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.Curso.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                dc.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
            }
            catch (Exception e)
            {
                throw new Exception("Error al asignar cargo", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}
