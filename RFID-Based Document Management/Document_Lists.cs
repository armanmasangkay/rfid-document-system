using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Based_Document_Management.Library.Repositories;
using RFID_Based_Document_Management.Library.Models;
using RFID_Based_Document_Management.Library.Database;
using RFID_Based_Document_Management.Library.Services;
using MySql.Data.MySqlClient;

namespace RFID_Based_Document_Management
{
    public partial class Document_Lists : UserControl
    {

        private DocumentsRepository documentsRepository;
        private FoldersRepository foldersRepository;
       
        public Document_Lists()
        {
            InitializeComponent();
            DatabaseConnection connection = new DatabaseConnection();
            this.foldersRepository = new FoldersRepository(connection);
            this.documentsRepository = new DocumentsRepository(connection, new Library.Services.Parsers.DocumentStatusParser(), foldersRepository);
        }

        private void GunaButton5_Click(object sender, EventArgs e)
        {

        }
        private void populateDocumentList(ArrayList documents)
        {
            gunaDataGridView1.Rows.Clear();
            foreach (Document doc in documents)
            {
                gunaDataGridView1.Rows.Add(doc.Tag, doc.Folder.Id, doc.Owner, doc.Date, doc.Folder.Id, doc.Folder.Name, doc.Status.ToString(), doc.CreatedAt);
            }
        }

        private void Document_Lists_Load(object sender, EventArgs e)
        {
            this.populateDocumentList(documentsRepository.getAll());
            int currentYear = DateTime.Now.Year;
            int numberOfIterations = 100;
            object[] years = new object[numberOfIterations];

            for(int i=0;i<numberOfIterations;i++)
            {
                years[i] = currentYear-i;
            }

            gunaComboBox1.Items.AddRange(documentsRepository.getOwners());
            gunaComboBox2.Items.AddRange(foldersRepository.getIds());



            gunaComboBox3.Items.AddRange(years);
        }

        private void GunaButton4_Click(object sender, EventArgs e)
        {
            string owner = "";
            string type = "";
            if(gunaComboBox1.SelectedIndex!=0)
            {
                owner = gunaComboBox1.SelectedItem.ToString();
            }
            if (gunaComboBox2.SelectedIndex!=0)
            {
                type = gunaComboBox2.SelectedItem.ToString();
            }

            ArrayList documents=documentsRepository.getDocumentsWith(owner,type, "2020","01");
            this.populateDocumentList(documents);
        }
    }
}
