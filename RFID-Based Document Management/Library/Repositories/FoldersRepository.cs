using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Models;
using MySql.Data.MySqlClient;
namespace RFID_Based_Document_Management.Library.Repositories
{
    class FoldersRepository
    {

        private MySqlConnection connection;
        public FoldersRepository(DatabaseConnection connection)
        {

            this.connection = connection.get();

        }

        public ArrayList getAll()
        {
            this.connection.Open();
            string sql = "SELECT * FROM folders";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            ArrayList folders = new ArrayList();
            while (reader.Read())
            {
                folders.Add(new Folder(reader[0].ToString(), reader[1].ToString()));
            }
            this.connection.Close();

            return folders;
        }

  
        private MySqlDataReader readFolderById(string strColumns,string id)
        {
            string sql = "SELECT "+strColumns +" FROM folders WHERE id=@id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteReader();
     
        }

        public string getNameById(string id)
        {
            this.connection.Open();
            MySqlDataReader reader = this.readFolderById("name",id);
            string name = "";
            while (reader.Read())
            {
                name = reader[0].ToString();
            }
            this.connection.Close();

            return name;
        }

        public string getIdByName(string name)
        {
            this.connection.Open();
            string sql = "SELECT id FROM folders WHERE name=@name";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            MySqlDataReader reader = command.ExecuteReader();
            string id = "";
            while (reader.Read())
            {
                id = reader[0].ToString();
            }
            this.connection.Close();

            return id;
        }

        public Folder getFolderById(string id)
        {
            this.connection.Open();
            MySqlDataReader reader = this.readFolderById("*",id);
            Folder folder=null;
            while (reader.Read())
            {
                folder = new Folder(reader[0].ToString(), reader[1].ToString());
            }
            this.connection.Close();

            return folder;
        }

        private object[] getSingleColumnValues(string columName)
        {
            this.connection.Open();
            string sql = "SELECT "+columName+" FROM folders";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList ids = new ArrayList();
            while (reader.Read())
            {
                ids.Add(reader[0].ToString());
            }
            this.connection.Close();
            return ids.ToArray();
        }

        public object[] getIds()
        {
            return this.getSingleColumnValues("id");
        }

        public object[] getNames()
        {
            return this.getSingleColumnValues("name");
        }

    }
}
