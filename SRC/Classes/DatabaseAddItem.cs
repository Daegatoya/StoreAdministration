using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseAddItem : DatabaseParent
    {
        private MySqlDataReader? reader = null;
        private string itemName;

        public DatabaseAddItem(string password, string request, string itemName)
        : base(password, request)
        {
            try
            {
                this.itemName = itemName;
                this.request = $"AddItem";
                if (!CheckIfExist())
                {
                    Command.CommandText = this.request;
                    Command.CommandType = System.Data.CommandType.StoredProcedure;
                    Command.Connection = Connection;
                    Command.Parameters.AddWithValue("@item_name", this.itemName);
                    Command.ExecuteNonQuery();
                    Console.WriteLine($"\n\"{itemName}\" Added successfully with the default amount 0");
                }
                else Console.WriteLine($"\n\"{itemName}\" Already exists");
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        private bool CheckIfExist()
        {
            try
            {
                string request = $"SELECT * FROM stocks;";
                Command.CommandText = request;
                Command.CommandType = System.Data.CommandType.Text;
                Command.Connection = Connection;
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader.GetString("item");
                    if (itemName == value) return true;
                }
                return false;
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
                return false;
            }
            catch (IndexOutOfRangeException err)
            {
                Console.WriteLine(err.ToString());
                return false;
            }
            finally { if (reader != null) reader.Close(); }
        }
    }
}
