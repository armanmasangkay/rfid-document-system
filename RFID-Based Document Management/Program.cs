using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Repositories;

namespace RFID_Based_Document_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //User user=new User("13","1234",UserRole.Admin);

            //UsersRepository usersRepo = new UsersRepository(new DatabaseConnection());
            //usersRepo.save(user);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}
