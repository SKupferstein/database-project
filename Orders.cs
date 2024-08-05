using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    class Orders
    {
        public void NewOrder(string supplier)
        {

        }
        public int NewOrder(int supplierID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NewOrder";//name of procedure
                cmd.Parameters.AddWithValue("@supplier", supplierID);

                return (int)cmd.ExecuteScalar();

                library.Closeconn();
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error creating order");
                return -1;
            }
        }
        public void AddBookToOrder(int orderID, string bookName, string author, decimal price, int qnt)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddBookToOrder";//name of procedure
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.Parameters.AddWithValue("@BookName", bookName);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@BookPrice", price);
                cmd.Parameters.AddWithValue("@Quantity", qnt);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine(rowsAffected + " book added to order.");
                }
                else
                {
                    Console.WriteLine("Wrong information.\nPlease try again.");
                }
                library.Closeconn();
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error adding book to order.");
            }
        }
        public void OrderSum(int orderID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShowOrderSum";//name of procedure
                cmd.Parameters.AddWithValue("order", orderID);

                library.Closeconn();
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error calculating sum.");
            }
        }
        public void RecieveOrder(int orderID)
        {
            try
            {
                Connect library = new Connect();
                library.OpenConn();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = library.GetConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RecieveOrder";//name of procedure
                cmd.Parameters.AddWithValue("OrderID", orderID);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " rows affected");
                library.Closeconn();
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error recieving order.");
            }
        }
    }

}
