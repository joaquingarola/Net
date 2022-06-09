using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Lab02
{
    class fileHandler
    {

        protected DataTable myContacts;

        public fileHandler()
        {
            this.myContacts = this.getTable();
        }

        public virtual DataTable getTable()
        {
            return new DataTable();
        }

        public virtual void applyChanges()
        {

        }

        public void list()
        {
            foreach(DataRow row in this.myContacts.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    foreach(DataColumn col in this.myContacts.Columns)
                    {
                        Console.WriteLine("{0}: {1}", col.ColumnName, row[col]);
                    }
                    Console.WriteLine();
                      
                }
            }
        }


        public void newRow()
        {
            DataRow row = this.myContacts.NewRow();

            foreach(DataColumn col in this.myContacts.Columns)
            {
                Console.WriteLine("Input {0}: ", col.ColumnName);
                row[col] = Console.ReadLine();
            }
            this.myContacts.Rows.Add(row);
        }


        public void editRow()
        {
            Console.WriteLine("Input the number of row to be changed");
            int numRow = int.Parse(Console.ReadLine());
            DataRow row = this.myContacts.Rows[numRow - 1];

            for (int numCol = 1; numCol < this.myContacts.Columns.Count; numCol++)
                // El 0 se omite por ser el Id
            {
                DataColumn col = this.myContacts.Columns[numCol];
                Console.WriteLine("Input {0}: ", col.ColumnName);
                row[col] = Console.ReadLine();
            }
        }


        public void deleteRow()
        {
            Console.WriteLine("Input the number of row to be deleted");
            int row = int.Parse(Console.ReadLine());
            this.myContacts.Rows[row - 1].Delete();

        }


        /* 
            Los métodos getTable y applyChanges tienen el modificador virtual 
            para permitir ser sobrescritos en las clases hijas
         */



    }
}
