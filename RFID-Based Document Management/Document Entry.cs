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
using RFID_Based_Document_Management.Library.Repositories;
using RFID_Based_Document_Management.Library.Services;

namespace RFID_Based_Document_Management
{
    public partial class Document_Entry : UserControl
    {
        Library.Database.DatabaseConnection databaseConnection;
        FoldersRepository foldersRepository;
        DocumentsRepository documentsRepository;
        public Document_Entry()
        {
            InitializeComponent();
            this.databaseConnection = new Library.Database.DatabaseConnection();
            this.foldersRepository = new FoldersRepository(databaseConnection);
            this.documentsRepository = new DocumentsRepository(databaseConnection);
        }

        private void populateDocumentList(ArrayList documents=null)
        {
            if (documents == null)
            {
                documents = documentsRepository.getAll(this.foldersRepository);
            }
        

            gunaDataGridView1.Rows.Clear();

            foreach (Document doc in documents)
            {
                gunaDataGridView1.Rows.Add(doc.Tag, doc.Folder.Id, doc.Owner, doc.Date);
            }
        }

        private void GunaButton3_Click(object sender, EventArgs e)
        {     

            try
            {
                Folder folder = new Folder(gunaTextBox3.Text, gunaTextBox4.Text);
                Document document = new Document(gunaTextBox1.Text,
                                           gunaTextBox2.Text,
                                           StringHelper.toMysqlDateString(gunaDateTimePicker1.Value.ToString()),
                                           folder);
                this.documentsRepository.save(document);
                MessageBox.Show("Documents saved successfully!", "Great!");

                this.populateDocumentList();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
           
           
            
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
                gunaComboBox2.Items.Add(folder.Id);

            }

            if (gunaComboBox1.Items.Count > 0)
            {
                gunaComboBox1.SelectedIndex = 0;
                gunaComboBox2.SelectedIndex = 0;
                this.changeFolderDetailsBasedOnType();
            }
            this.populateDocumentList();

        }

        private void Document_Entry_VisibleChanged(object sender, EventArgs e)
        {
         
            

        }

        private void GunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ArrayList documents = gunaComboBox2.SelectedIndex != 0
                                   ?
                                   documentsRepository.getDocumentsFromFolder(
                                  foldersRepository.getFolderById(gunaComboBox2.SelectedItem.ToString())
                                  )
                                  :
                                   documents = documentsRepository.getAll(foldersRepository); ;

            this.populateDocumentList(documents);
          
            
        }
    }
}
