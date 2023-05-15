using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseShow : DatabaseParent
    {
        private MySqlDataReader? reader = null;

        public DatabaseShow(string password, string request, string requestedItem)
        : base(password, request)
        {
            try
            {
                this.request = $"SELECT * FROM `stocks` WHERE item = '{requestedItem}'";
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
            }
            ShowResult();
        }

        private string ReadRequested()
        {
            try
            {
                Command.CommandText = request;
                Command.CommandType = System.Data.CommandType.Text;
                Command.Connection = Connection;
                reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)Convert.ToInt64(reader.GetValue(0));
                    string item = reader.GetValue(1).ToString() ?? "Unknown";
                    int amount = (int)Convert.ToInt64(reader.GetValue(2));
                    int awaiting_delivery = (int)Convert.ToInt64(reader.GetValue(3));

                    return $"\n\nID : {id}\nName of Item : {item}\nAmount in Stocks : {amount}\nAmount Awaiting Delivery : {awaiting_delivery}";
                }
                return null;
            }
            catch (MySqlException err)
            {
                return err.ToString();
            }
            finally { if (reader != null) reader.Close(); }
        }

        private void ShowResult()
        {
            Console.WriteLine(ReadRequested());
        }
    }
}
