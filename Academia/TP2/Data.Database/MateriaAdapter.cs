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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan = new Plan();
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar la lista de materias", e);
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetMateriasPlan(Plan plan)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_plan=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan = plan;
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetPosibles(int IDAlumno)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT mat.id_materia,desc_materia, hs_semanales, hs_totales " +
                    "FROM materias mat INNER JOIN planes pla ON mat.id_plan = pla.id_plan " +
                    "INNER JOIN(SELECT id_persona, id_plan FROM personas WHERE id_persona = @id_alu) alu " +
                    "ON alu.id_plan = pla.id_plan WHERE mat.id_materia NOT IN " +
                    "(SELECT distinct id_materia FROM cursos cur INNER JOIN alumnos_inscripciones alu_ins " +
                    "ON cur.id_curso = alu_ins.id_curso WHERE id_alumno = @id_alu AND condicion != @condicion)", sqlConn);
                cmdMaterias.Parameters.Add("@id_alu", SqlDbType.Int).Value = IDAlumno;
                cmdMaterias.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = AlumnoInscripcion.Condiciones.Libre;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    materias.Add(mat);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de posibles materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan = new Plan();
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
                PlanAdapter pa = new PlanAdapter();
                mat.Plan = pa.GetOne(mat.Plan.ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave =
                    new SqlCommand("UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales, hs_totales=@hs_totales, id_plan=@id_plan " +
                    "WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.Plan.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave =
                    new SqlCommand("insert into materias(desc_materia, hs_semanales, hs_totales, id_plan)" +
                    "values(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.Plan.ID;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                materia.ID = Decimal.ToInt32((Decimal)cmdSave.ExecuteNonQuery());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
