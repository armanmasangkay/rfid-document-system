using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RFID_Based_Document_Management.Library.Database;

namespace RFID_Based_Document_Management.Library.Repositories
{
    class StoragesRepository
    {

        private MySqlConnection connection;
        public StoragesRepository(DatabaseConnection connection)
        {

            this.connection = connection.get();

        }

        public object[] getStorages()
        {
            this.connection.Open();
            string sql = "SELECT id from storages";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList storages = new ArrayList();
            while (reader.Read())
            {
                storages.Add(reader[0].ToString());
            }
            this.connection.Close();

            return storages.ToArray();

        }

        public void createNew()
        {
            this.connection.Open();
            string sql = "INSERT INTO storages VALUES()";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.ExecuteNonQuery();
            this.connection.Close();
        }

    }
}
