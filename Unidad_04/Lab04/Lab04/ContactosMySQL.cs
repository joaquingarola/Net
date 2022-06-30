using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Lab04
{
    class ContactosMySQL : Contactos
    {
        protected string connectionString
        {
            get
            {
                return "server = serverisi; database = net; uid = net; pwd = net";
            }
        }
        public override DataTable getTabla()
        {
            using (MySqlConnection Conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdSelect = new MySqlCommand("select * from contactos", Conn);
                Conn.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                {
                    contactos.Load(reader);
                }
                Conn.Close();
                return contactos;
            }
        }

        public override void aplicaCambios()
        {
            using (MySqlConnection Conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdInsert = new MySqlCommand("insert into contactos" +
               "values(@id,@nombre,@apellido,@email,@telefono)", Conn);
                cmdInsert.Parameters.Add("@id", MySqlDbType.Int32);
                cmdInsert.Parameters.Add("@nombre", MySqlDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", MySqlDbType.VarChar);
                cmdInsert.Parameters.Add("@email", MySqlDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", MySqlDbType.VarChar);

                MySqlCommand cmdUpdate = new MySqlCommand(
                "update contactos set nombre=@nombre, apellido=@apellido, " +
                    "email=@email,telefono=@telefono where id=@id", Conn);
                cmdUpdate.Parameters.Add("@id", MySqlDbType.Int32);
                cmdUpdate.Parameters.Add("@nombre", MySqlDbType.VarChar);
                cmdUpdate.Parameters.Add("@apellido", MySqlDbType.VarChar);
                cmdUpdate.Parameters.Add("@email", MySqlDbType.VarChar);
                cmdUpdate.Parameters.Add("@telefono", MySqlDbType.VarChar);

                MySqlCommand cmdDelete = new MySqlCommand("delete from contactos where id=@id",
                                        Conn);
                cmdDelete.Parameters.Add("@id", MySqlDbType.Int32);

                DataTable filasNuevas = this.misContactos.GetChanges(DataRowState.Added);
                DataTable filasBorradas = this.misContactos.GetChanges(DataRowState.Deleted);
                DataTable filasModificadas = this.misContactos.GetChanges(DataRowState.Modified);

                Conn.Open();

                if (filasNuevas != null)
                {
                    foreach (DataRow fila in filasNuevas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["id"];
                        cmdInsert.Parameters["@nombre"].Value = fila["nombre"];
                        cmdInsert.Parameters["@apellido"].Value = fila["apellido"];
                        cmdInsert.Parameters["@email"].Value = fila["email"];
                        cmdInsert.Parameters["@telefono"].Value = fila["telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                if (filasBorradas != null)
                {
                    foreach (DataRow fila in filasBorradas.Rows)
                    {
                        cmdDelete.Parameters["@id"].Value = fila["id", DataRowVersion.Original];
                        cmdDelete.ExecuteNonQuery();
                    }
                }
                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        cmdUpdate.Parameters["@id"].Value = fila["id"];
                        cmdUpdate.Parameters["@nombre"].Value = fila["nombre"];
                        cmdUpdate.Parameters["@apellido"].Value = fila["apellido"];
                        cmdUpdate.Parameters["@email"].Value = fila["email"];
                        cmdUpdate.Parameters["@telefono"].Value = fila["telefono"];
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                Conn.Close();
                this.misContactos.AcceptChanges();
            }
        }

    }
}
