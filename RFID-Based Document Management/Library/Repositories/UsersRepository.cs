using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Database;
using MySql.Data.MySqlClient;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Services;
namespace RFID_Based_Document_Management.Library.Repositories
{
    class UsersRepository
    {
        private MySqlConnection connection;

        private UserRoleParser parser;

        public UsersRepository(DatabaseConnection connection,UserRoleParser parser)
        {

            this.connection = connection.get();
            this.parser = parser;

        }

        public bool isExistingId(string employeeId)
        {
            this.connection.Open();
            string sql = "SELECT COUNT(*) FROM users WHERE employee_id=@employeeId";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@employeeId", employeeId);
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

        private ArrayList getUsers(string sql)
        {
            this.connection.Open();

            MySqlCommand command = new MySqlCommand(sql, this.connection);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList users = new ArrayList();
            while (reader.Read())
            {
                users.Add(new User(reader[0].ToString(),
                                   reader[1].ToString(),
                                   parser.parseString(reader[2].ToString()),
                                   reader[3].ToString()));

            }
            this.connection.Close();
            return users;
        }

        public ArrayList getAll()
        {
            string sql = "SELECT * FROM users ORDER BY created_at DESC";
           return this.getUsers(sql);

        }

        public ArrayList getUsersWithIdsLike(string employeeIdKeyword)
        {
            string sql = "SELECT * FROM users WHERE employee_id LIKE '%"+employeeIdKeyword+ "%' ORDER BY created_at DESC ";
            return this.getUsers(sql);

        }

        public void delete(string employeeId)
        {
            this.connection.Open();
            string sql = "DELETE FROM users WHERE employee_id=@employeeId";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@employeeId", employeeId);
            command.ExecuteNonQuery();
            this.connection.Close();

        }

        public void deleteAll()
        {
            this.connection.Open();
            string sql = "DELETE FROM users";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.ExecuteNonQuery();
            this.connection.Close();

        }

     

        public void save(User user)
        {
            if (this.isExistingId(user.EmployeeId))
            {
                throw new Exception("Employee ID already exist");
            }

            this.connection.Open();
            string sql = "INSERT INTO users(employee_id,password,role) VALUES(@employeeId,@password,@role)";
            MySqlCommand command = new MySqlCommand(sql, this.connection);
            command.Parameters.AddWithValue("@employeeId", user.EmployeeId);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@role", user.Role.ToString());
            command.ExecuteNonQuery();
            this.connection.Close();
        }
    }
}
