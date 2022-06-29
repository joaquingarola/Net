using System;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=DESKTOP-DI7EDGP;Initial Catalog=Northwind;Integrated Security=True";

            SqlCommand mycomando = new SqlCommand();
            mycomando.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            mycomando.Connection = myconn;

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);

            myconn.Open();
            SqlDataReader mydr = mycomando.ExecuteReader();
            dtEmpresas.Load(mydr);
            myconn.Close();

            Console.WriteLine("Listado de Empresas: ");
            foreach(DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nombreempresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idempresa + " - " + nombreempresa);
            }
            Console.ReadLine();
        }
    }
}
