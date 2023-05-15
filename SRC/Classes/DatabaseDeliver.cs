using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseDeliver : DatabaseParent
    {
        public DatabaseDeliver(string password, string request, string requestedItem, int amount_Delivered)
        : base(password, request)
        {
            try
            {
                this.request = $"Delivered";
                Command.CommandText = this.request;
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Connection = Connection;
                Command.Parameters.AddWithValue("@item_name", requestedItem);
                Command.Parameters.AddWithValue("@amount_delivered", amount_Delivered);
                Command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
