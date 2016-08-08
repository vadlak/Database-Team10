using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public class SqlManager
    {
        private string ConnectionString;
        private SqlConnection connection;


        public SqlManager(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            CreateConnection();
        }

        private bool CreateConnection()
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error Opening DB Connection " + e.ToString());
            }
            return false;
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }
        public SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
        public SqlDataReader ExecuteQuery(SqlCommand command)
        {
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
    }
}
