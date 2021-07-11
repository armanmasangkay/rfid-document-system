using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Based_Document_Management.Library.Repositories;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Models;

namespace RFID_Based_Document_Management
{
    public partial class Return_Document : UserControl
    {
        private DocumentsRepository documentsRepository;
        private FoldersRepository foldersRepository;
        private Document currentDocument = null;
        public Return_Document()
        {
            InitializeComponent();

            DatabaseConnection connection = new DatabaseConnection();
            this.foldersRepository = new FoldersRepository(connection);
            this.documentsRepository = new DocumentsRepository(connection,new Library.Services.Parsers.DocumentStatusParser(),foldersRepository);
        }

        private void GunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void GunaTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
          
            if(e.KeyCode!=Keys.Enter)
            {
                return;
               
            }
            this.currentDocument = this.documentsRepository.getByTag(gunaTextBox1.Text);

            if(this.currentDocument.Status==DocumentStatus.In)
            {
                MessageBox.Show("A document that is still in the shelf cannot be returned!", "Error");
                this.currentDocument = null;
                return;
            }

            if (this.currentDocument != null)
            {
                gunaTextBox2.Text = this.currentDocument.Owner;
                gunaDateTimePicker1.Value = DateTime.Parse (this.currentDocument.Date);

                for (int i = 0; i < gunaComboBox1.Items.Count; i++)
                {
                    string value = gunaComboBox1.GetItemText(gunaComboBox1.Items[i]);
                    if(value== this.currentDocument.Folder.Id)
                    {
                        gunaComboBox1.SelectedIndex = i;
                        gunaTextBox3.Text = this.currentDocument.Folder.Id;
                        gunaTextBox4.Text = this.currentDocument.Folder.Name;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tag not found!", "Not Found");
            }
        }

        private void Return_Document_Load(object sender, EventArgs e)
        {
            foreach (Folder folder in foldersRepository.getAll())
            {
                gunaComboBox1.Items.Add(folder.Id);

            }
        }

        private void GunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.changeFolderInfoFromSelectedFolderType(gunaComboBox1, gunaTextBox3, gunaTextBox4, foldersRepository);
        }

        private void GunaButton3_Click(object sender, EventArgs e)
        {
            if(this.currentDocument==null)
            {
                MessageBox.Show("You must scan a document first!", "Error");
                return;
            }
            documentsRepository.updateStatus(this.currentDocument.Tag, DocumentStatus.In);
            documentsRepository.updateFolderId(this.currentDocument.Tag, gunaComboBox1.SelectedItem.ToString());
            MessageBox.Show("Document returned successfully!", "Great!");

            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
            gunaTextBox3.Text = "";
            gunaTextBox4.Text = "";
        }
    }
}
