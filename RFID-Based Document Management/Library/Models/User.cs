using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Services;
namespace RFID_Based_Document_Management.Library.Models
{
    public enum UserRole
    {
        Admin,
        Cashier
    }

    class User
    {

        public string EmployeeId { get;  }
        public string Password { get; }

        public UserRole Role { get; }

        public string DateCreated { get; set; }

        public User(string employeeId,string password,UserRole role,string dateCreated="")
        {

            StringHelper.throwIfEmpty(employeeId, "Employee ID is required");
            StringHelper.throwIfEmpty(password, "Password is required");

            this.EmployeeId = employeeId;
            this.Password = password;
            this.Role = role;
            this.DateCreated = dateCreated;
        }

   


    }
}
