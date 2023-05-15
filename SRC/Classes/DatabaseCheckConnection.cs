using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StoreManagement.Classes;

namespace StoreManagement.Classes
{
    internal class DatabaseCheckConnection : DatabaseParent
    {
        public DatabaseCheckConnection(string password, string? request)
        : base(password, (string?)request)
        {
        }
    }
}
