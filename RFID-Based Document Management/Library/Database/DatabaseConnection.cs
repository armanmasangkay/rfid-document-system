using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace RFID_Based_Document_Management.Library.Database
{
    class DatabaseConnection
    {
      
        public MySqlConnection get()
        {
            string host = ConfigurationManager.AppSettings.Get("host");
            string user = ConfigurationManager.AppSettings.Get("user");
            string password = ConfigurationManager.AppSettings.Get("password");
            string db = ConfigurationManager.AppSettings.Get("db_name");
            string connectionString = "server=" + host + ";user=" + user + ";database=" + db + ";port=3306;password=" + password;
            return new MySqlConnection(connectionString);

        }

    }
}
