using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseParent
    {
        protected string connectionString;
        protected string request;
        protected MySqlConnection? Connection = null;
        protected MySqlCommand Command = new MySqlCommand();

        protected DatabaseParent(string password, string request)
        {
            connectionString = $"server=127.0.0.1;port=3306;uid=root;pwd={password.Replace(" ", "")};database=new db";
            this.request = request;
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
                Environment.Exit(0x0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(0x1);
            }
            finally
            {
                ConnectionIsNull();
            }
        }

        protected void ConnectionIsNull()
        {
            if (Connection == null)
            {
                throw new Exception("Error : Null Connection");
            }
        }
    }
}
