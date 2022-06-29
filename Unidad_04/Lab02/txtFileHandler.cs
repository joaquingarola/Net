using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Lab02
{
    class txtFileHandler: fileHandler
    {
        protected string connectionString
        {
            get
            {
                return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\joaqu\Desktop\Facultad\2022\Net\Unidad_04\Lab02\bin\Debug\net5.0;" +
                        "Extended Properties='text;HDR=Yes;FMT=Delimited'";
            }
        }

        public override DataTable getTable()
        {
            using (OleDbConnection Conn = new(connectionString))
            {
                OleDbCommand cmdSelect = new("select * from agenda.txt", Conn);
                Conn.Open();
                OleDbDataReader reader = cmdSelect.ExecuteReader();
                DataTable contacts = new DataTable();

                if (reader != null)
                {
                    contacts.Load(reader);
                }

                Conn.Close();
                return contacts;
            }
        }


        public override void applyChanges()
        {
            using (OleDbConnection Conn = new(connectionString))
            {
                OleDbCommand cmdInsert = new("insert into agenda.txt values (@id, @nombre, @apellido, @email, @telefono)", Conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdUpdate = new("update agenda.txt set nombre=@hombre, apellido=@apellido, " +
                                        "email=@email, telefono=@telefono where id=@id", Conn);
                cmdUpdate.Parameters.Add("@id", OleDbType.Integer);
                cmdUpdate.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@email", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdDelete = new("delete from agenda.txt where id=@id", Conn);
                cmdDelete.Parameters.Add("@id", OleDbType.Integer);

                DataTable newRows = this.myContacts.GetChanges(DataRowState.Added);
                DataTable deletedRows = this.myContacts.GetChanges(DataRowState.Deleted);
                DataTable modifiedRows = this.myContacts.GetChanges(DataRowState.Modified);

                Conn.Open();

                if (newRows != null)
                {
                    foreach(DataRow row in newRows.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = row["id"];
                        cmdInsert.Parameters["@nombre"].Value = row["nombre"];
                        cmdInsert.Parameters["@apellido"].Value = row["apellido"];
                        cmdInsert.Parameters["@gmail"].Value = row["email"];
                        cmdInsert.Parameters["@telefono"].Value = row["telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                if (deletedRows != null)
                {
                    foreach(DataRow row in deletedRows.Rows)
                    {
                        cmdDelete.Parameters["@id"].Value = row["id", DataRowVersion.Original];
                        cmdDelete.ExecuteNonQuery();
                    }
                }

                if (modifiedRows != null)
                {
                    foreach(DataRow row in modifiedRows.Rows)
                    {
                        cmdUpdate.Parameters["@id"].Value = row["id"];
                        cmdUpdate.Parameters["@nombre"].Value = row["nombre"];
                        cmdUpdate.Parameters["@apellido"].Value = row["apellido"];
                        cmdUpdate.Parameters["@email"].Value = row["email"];
                        cmdUpdate.Parameters["@telefono"].Value = row["telefono"];
                    }
                }
            }
        }
    }
}
