using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Repositories;

namespace RFID_Based_Document_Management
{
    public partial class Document_Entry : UserControl
    {

        FoldersRepository foldersRepository = new FoldersRepository(new Library.Database.DatabaseConnection());
        public Document_Entry()
        {
            InitializeComponent();
        }

        private void GunaButton3_Click(object sender, EventArgs e)
        {
            Document document = new Document(gunaTextBox1.Text,
                                            gunaComboBox1.SelectedItem.ToString(),
                                            gunaDateTimePicker1.Value.ToString(),
                                            new Folder(gunaTextBox3.Text, gunaTextBox4.Text));

            MessageBox.Show(document.Tag);
        }

        private void changeFolderDetailsBasedOnType()
        {
            string folderType = gunaComboBox1.SelectedItem.ToString();
            gunaTextBox3.Text =folderType ;
            gunaTextBox4.Text = foldersRepository.getNameById(folderType);

        }

        private void GunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.changeFolderDetailsBasedOnType();
        }

        private void Document_Entry_Load(object sender, EventArgs e)
        {

            foreach (Folder folder in foldersRepository.getAll())
            {
                gunaComboBox1.Items.Add(folder.Id);

            }

            if (gunaComboBox1.Items.Count > 0)
            {
                gunaComboBox1.SelectedIndex = 0;
                this.changeFolderDetailsBasedOnType();
            }

        }

        private void Document_Entry_VisibleChanged(object sender, EventArgs e)
        {
         
            

        }
    }
}
