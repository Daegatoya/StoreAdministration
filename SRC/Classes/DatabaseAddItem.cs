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
        public DatabaseAddItem(string password, string request, string itemName)
        : base(password, request)
        {
            try
            {
                this.request = $"AddItem";
                Command.CommandText = this.request;
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Connection = Connection;
                Command.Parameters.AddWithValue("@item_name", itemName);
                Command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
