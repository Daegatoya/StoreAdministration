using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseSendDelivery : DatabaseParent
    {
        public DatabaseSendDelivery(string password, string request, string requestedItem, int amount_Delivery)
        : base(password, request)
        {
            try
            {
                this.request = $"AddDelivery";
                Command.CommandText = this.request;
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Connection = Connection;
                Command.Parameters.AddWithValue("@item_name", requestedItem);
                Command.Parameters.AddWithValue("@amount_delivery", amount_Delivery);
                Command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
