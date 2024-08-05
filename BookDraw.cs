using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    class BookDraw
    {
       

        public void DrawBook(int memberID, int bookID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DrawBook";//name of procedure
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                cmd.Parameters.AddWithValue("@BookID", bookID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine(rowsAffected + " book drawed.");
                }
                else
                {
                    Console.WriteLine("Wrong book ID.\nPlease try again.");
                }
                library.Closeconn();
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Wrong book ID.");
                
            }
            
        }
        public void ReturnBook(int memberID, int bookID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReturnBook";//name of procedure
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                cmd.Parameters.AddWithValue("@BookID", bookID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine(rowsAffected + " book returned.");
                }
                else
                {
                    Console.WriteLine("Wrong book ID.\nPlease try again.");
                }
                library.Closeconn();

                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Wrong book ID.");
            }
        }
        public int NumBooksEligable(int memberID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NumBooksCurrentlyEligable";//name of procedure
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                return (int)cmd.ExecuteScalar(); 

                library.Closeconn();

                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error finding member ID");
                return -1;
            }
        }
        public int BooksDrawed(int memberID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ViewDrawedBooks";//name of procedure
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                return (int)cmd.ExecuteScalar(); 
                library.Closeconn();

                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error finding member ID");
                return -1;
            }
        }
    }
}
