using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Repositories;
using RFID_Based_Document_Management.Library.Services;

namespace RFID_Based_Document_Management
{
    public partial class User_Account : UserControl
    {

        UsersRepository usersRepository = new UsersRepository(new DatabaseConnection(),new UserRoleParser());
        public User_Account()
        {
            InitializeComponent();
            this.gunaComboBox1.Items.AddRange(System.Enum.GetNames(typeof(UserRole)));
            gunaComboBox1.SelectedIndex = 0;
        }

        private void populateUsersListView(ArrayList users=null)
        {
            gunaDataGridView1.Rows.Clear();

            if (users == null)
            {
                users = usersRepository.getAll();
            }
     

            foreach (User user in users)
            {
                gunaDataGridView1.Rows.Add(user.EmployeeId, user.Password, user.Role.ToString(),user.DateCreated);
            }
        }

        private void GunaButton3_Click(object sender, EventArgs e)
        {
            UserRole selectedRole;
            switch (gunaComboBox1.SelectedIndex)
            {
                case 0:
                    selectedRole = UserRole.Admin;
                    break;
                case 1:
                    selectedRole = UserRole.Cashier;
                    break;
                default:
                    selectedRole = UserRole.Admin;
                    break;

            }
    
            try
            {
                User user = new User(gunaTextBox1.Text, gunaTextBox3.Text, selectedRole);
                usersRepository.save(user);
                MessageBox.Show("Account created successfully!", "Great!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }


            this.populateUsersListView();
            gunaTextBox1.Text = "";
            gunaTextBox3.Text = "";

        }

        private void User_Account_Load(object sender, EventArgs e)
        {
            this.populateUsersListView();
        }

        private void GunaButton2_Click(object sender, EventArgs e)
        {
          foreach(DataGridViewRow row in gunaDataGridView1.SelectedRows)
            {
                if( row.Cells[0].Value.ToString()!=null)
                {
                    string selectedEmployeeId = row.Cells[0].Value.ToString();
                    usersRepository.delete(selectedEmployeeId);
                    this.populateUsersListView();
                }
                else
                {
                    MessageBox.Show("An error occured while deleting row!","Oops!");
                }
               
            }
           
        }

        private void GunaButton5_Click(object sender, EventArgs e)
        {
            usersRepository.deleteAll();
            this.populateUsersListView();
        }

        private void GunaButton4_Click(object sender, EventArgs e)
        {
            this.populateUsersListView(usersRepository.getUsersWithIdsLike(gunaTextBox5.Text));
            
        }
    }
}
