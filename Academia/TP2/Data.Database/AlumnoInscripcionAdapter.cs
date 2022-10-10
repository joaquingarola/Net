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
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> getInscripcionesCurso(Curso cu)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdSELECT = new SqlCommand("SELECT id_curso, id_alumno, id_inscripcion, condicion, nota " +
                    "FROM alumnos_inscripciones where id_curso = @id", sqlConn);
                cmdSELECT.Parameters.Add("@id", SqlDbType.Int).Value = cu.ID;
                SqlDataReader reader = cmdSELECT.ExecuteReader();
                while (reader.Read())
                {
                    AlumnoInscripcion insc = new AlumnoInscripcion();
                    switch ((string)reader["condicion"])
                    {
                        case ("Libre"):
                            insc.Condicion = AlumnoInscripcion.Condiciones.Libre;
                            break;

                        case ("Inscripto"):
                            insc.Condicion = AlumnoInscripcion.Condiciones.Inscripto;
                            break;

                        case ("Cursando"):
                            insc.Condicion = AlumnoInscripcion.Condiciones.Cursando;
                            break;

                        case ("Aprobado"):
                            insc.Condicion = AlumnoInscripcion.Condiciones.Aprobado;
                            insc.Nota = (int)reader["nota"];
                            break;

                        case ("Regular"):
                            insc.Condicion = AlumnoInscripcion.Condiciones.Regular;
                            break;
                    }
                    insc.ID = (int)reader["id_inscripcion"];
                    insc.Curso = new Curso();
                    insc.Curso.ID = (int)reader["id_curso"];
                    insc.Alumno = new Persona();
                    insc.Alumno.ID = (int)reader["id_alumno"];
                    inscripciones.Add(insc);
                }
                reader.Close();
                foreach (AlumnoInscripcion insc in inscripciones)
                {
                    PersonaAdapter pa = new PersonaAdapter();
                    insc.Alumno = pa.GetOne(insc.Alumno.ID);
                    CursoAdapter ca = new CursoAdapter();
                    insc.Curso = ca.GetOne(insc.Curso.ID);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se han podido recuperar las inscripciones", e);
            }
            finally
            {
                CloseConnection();
            }
            return inscripciones;
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    aluInsc.ID = (int)drInscripciones["id_inscripcion"];
                    aluInsc.Alumno = new Persona();
                    aluInsc.Alumno.ID = (int)drInscripciones["id_alumno"];
                    aluInsc.Curso = new Curso();
                    aluInsc.Curso.ID = (int)drInscripciones["id_curso"];
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return aluInsc;
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(Persona alumno)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("SELECT id_inscripcion, id_curso FROM alumnos_inscripciones " +
                    "WHERE id_alumno = @id AND condicion = @condicion", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar).Value = Business.Entities.AlumnoInscripcion.Condiciones.Inscripto;
                SqlDataReader reader = cmdInscripcion.ExecuteReader();
                while (reader.Read())
                {
                    AlumnoInscripcion insc = new AlumnoInscripcion();
                    insc.ID = (int)reader["id_inscripcion"];
                    insc.Curso = new Curso();
                    insc.Curso.ID = (int)reader["id_curso"];
                    inscripciones.Add(insc);
                }
                reader.Close();
                foreach (AlumnoInscripcion insc in inscripciones)
                {
                    CursoAdapter ca = new CursoAdapter();
                    insc.Curso = ca.GetOne(insc.Curso.ID);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron recuperar las inscripciones", e);
            }
            finally
            {
                CloseConnection();
            }
            return inscripciones;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("SET XACT_ABORT ON; " +
                    "BEGIN TRANSACTION; " +
                    "UPDATE cursos SET cupo=cupo+1 WHERE id_curso=(SELECT id_curso FROM alumnos_inscripciones where id_inscripcion=@id) " +
                    "DELETE alumnos_inscripciones WHERE id_inscripcion=@id " +
                    "COMMIT TRANSACTION;", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion ai)
        {
            if (ai.State == BusinessEntity.States.New)
            {
                Insert(ai);
            }
            else if (ai.State == BusinessEntity.States.Deleted)
            {
                Delete(ai.ID);
            }
            else if (ai.State == BusinessEntity.States.Modified)
            {
                Update(ai);
            }
            ai.State = BusinessEntity.States.Unmodified;
        }

        public void Insert(AlumnoInscripcion ai)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdINSERT = new SqlCommand("SET XACT_ABORT ON; " +
                    "BEGIN TRANSACTION; " +
                    "IF (SELECT cupo FROM cursos WHERE id_curso=@idCur)>0 BEGIN " +
                    "INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion) " +
                    "values (@idAlu,@idCur,@condicion) select @@identity; " +
                    "UPDATE cursos SET cupo=cupo-1 WHERE id_curso=@idCur END " +
                    "COMMIT TRANSACTION; ", sqlConn);

                cmdINSERT.Parameters.Add("@idAlu", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdINSERT.Parameters.Add("@idCur", SqlDbType.Int).Value = ai.Curso.ID;
                cmdINSERT.Parameters.Add("@condicion", SqlDbType.VarChar).Value = Business.Entities.AlumnoInscripcion.Condiciones.Inscripto;

                ai.ID = Decimal.ToInt32((decimal)cmdINSERT.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception("Error al realizar la inscripción", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(AlumnoInscripcion ai)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUPDATE = new SqlCommand("UPDATE alumnos_inscripciones SET  id_alumno= @id_alumno,id_curso=@id_curso,condicion=@condicion, nota=@nota  where id_inscripcion=@id", sqlConn);
                cmdUPDATE.Parameters.Add("@id", SqlDbType.Int).Value = ai.ID;
                cmdUPDATE.Parameters.Add("@id_alumno", SqlDbType.Int).Value = ai.Alumno.ID;
                cmdUPDATE.Parameters.Add("@id_curso", SqlDbType.Int).Value = ai.Curso.ID;
                cmdUPDATE.Parameters.Add("@condicion", SqlDbType.VarChar).Value = ai.Condicion;
                cmdUPDATE.Parameters.Add("@nota", SqlDbType.Int).Value = ai.Nota;

                cmdUPDATE.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al modificar datos de la inscripcion", e);

            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
