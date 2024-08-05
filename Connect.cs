using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    class Connect
    {
        private SqlConnection conn;

        public Connect()
        {
            try { conn = new SqlConnection(@"Data Source=localhost; Initial Catalog = Library; Integrated Security = SSPI"); }
            catch { Console.WriteLine("Connection failed."); }
        }
        public void OpenConn()
        {
            try { conn.Open(); }
            catch { Console.WriteLine("Connection failed."); }
        }
        public void Closeconn()
        {
            try { conn.Close(); }
            catch { Console.WriteLine("Connection close failed."); }
        }
        public SqlConnection GetConn()
        {
            return conn;
        }
        public void PrintTable(string sqlCommand)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sqlCommand,conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataColumn dc in dt.Columns)
                {
                    Console.Write(dc + "\t");
                }
                Console.WriteLine();
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        Console.Write(dr[i] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch { Console.WriteLine("Could not load table."); }
        }
        public void ExecuteProcedure(string cmdText)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                Console.WriteLine("Error calling procedure");
            }

        }
        
    }
}
