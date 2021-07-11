using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID_Based_Document_Management.Library.Models;

namespace RFID_Based_Document_Management.Library.Services
{
    class UserRoleParser
    {
        public UserRole parseString(string roleString)
        {
            switch (roleString)
            {
                case "Admin":
                    return UserRole.Admin;
                case "Cashier":
                    return UserRole.Cashier;
                default:
                    throw new Exception("Role cannot be parsed!");
            }
        }
    }
}
