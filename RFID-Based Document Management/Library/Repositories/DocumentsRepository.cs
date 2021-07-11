using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Services;
using RFID_Based_Document_Management.Library.Services.Parsers;
using MySql.Data.MySqlClient;
namespace RFID_Based_Document_Management.Library.Repositories
{
    class DocumentsRepository
    {
        private MySqlConnection connection;
        private DocumentStatusParser parser;
        public DocumentsRepository(DatabaseConnection connection, DocumentStatusParser parser)
        {

            this.connection = connection.get();
            this.parser = parser;

        }
        public bool isExistingTag(string tag)
        {
            this.connection.Open();
            string sql = "SELECT COUNT(*) FROM documents WHERE tag=@tag";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@tag", tag);
            object result = command.ExecuteScalar();
            this.connection.Close();
            int count = 0;
            if (result != null)
            {
                count = Convert.ToInt32(result);
            }

            if (count <= 0)
            {
                return false;
            }

            return true;
        }


        public void save(Document document)
        {
            if(this.isExistingTag(document.Tag))
            {
                throw new Exception("Tag already exist!");
            }

            this.connection.Open();
            string sql="INSERT INTO documents(tag,folder_id,owner,doc_date,status) VALUES(@tag,@folderId,@owner,@docDate,@status)";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@tag", document.Tag);
            command.Parameters.AddWithValue("@folderId", document.Folder.Id);
            command.Parameters.AddWithValue("@owner", document.Owner);
            command.Parameters.AddWithValue("@docDate", document.Date);
            command.Parameters.AddWithValue("@status", document.Status.ToString());
            command.ExecuteNonQuery();
            this.connection.Close();
        }

        public ArrayList getAll(FoldersRepository foldersRepository)
        {
            this.connection.Open();
            string sql = "SELECT * FROM documents";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            MySqlDataReader reader = command.ExecuteReader();

            ArrayList documents = new ArrayList();
            while (reader.Read())
            {
                string date = StringHelper.removeTimeFromDate(reader[3].ToString());
                documents.Add(new Document(reader[0].ToString(),
                               reader[2].ToString(),
                               date,
                               foldersRepository.getFolderById(reader[1].ToString()),
                               status: this.parser.parseString(reader[4].ToString())));
            }
            this.connection.Close();
            return documents;
        }

        public ArrayList getDocumentsFromFolder(Folder folder)
        {
            this.connection.Open();
            string sql = "SELECT * FROM documents WHERE folder_id=@folderId";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@folderId", folder.Id);
            MySqlDataReader reader = command.ExecuteReader();

            ArrayList documents = new ArrayList();
            while (reader.Read())
            {

                documents.Add(new Document(reader[0].ToString(),
                               reader[2].ToString(),
                               StringHelper.removeTimeFromDate(reader[3].ToString()),
                               folder,
                               status:this.parser.parseString(reader[4].ToString())));
            }
            this.connection.Close();
            return documents;
        }
    }
}
