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
                gunaDataGridView1.Rows.Add(doc.Tag, doc.Folder.Name, doc.Owner, doc.Date, doc.Folder.Id, doc.Folder.Name, doc.Status.ToString(), doc.CreatedAt);
            }
        }

        private void Document_Lists_Load(object sender, EventArgs e)
        {
            this.populateDocumentList(documentsRepository.getAll());


            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames;
            string[] finalMonthNames = monthNames.Take(monthNames.Count() - 1).ToArray();
            string[] statuses = { "In", "Out" };

            int currentYear = DateTime.Now.Year;
            int numberOfIterations = 100;
            object[] years = new object[numberOfIterations];

            for(int i=0;i<numberOfIterations;i++)
            {
                years[i] = currentYear-i;
            }

            gunaComboBox1.Items.AddRange(documentsRepository.getOwners());
            gunaComboBox2.Items.AddRange(foldersRepository.getNames());
            gunaComboBox3.Items.AddRange(years);
            gunaComboBox4.Items.AddRange(finalMonthNames);
            gunaComboBox5.Items.AddRange(statuses);
        }

        private void GunaButton4_Click(object sender, EventArgs e)
        {
            string owner = "";
            string type = "";
            string year = "";
            string month = "";
            string status = "";
            if(gunaComboBox1.SelectedIndex!=0)
            {
                owner = gunaComboBox1.SelectedItem.ToString();
            }
            if (gunaComboBox2.SelectedIndex!=0)
            {
                type =foldersRepository.getIdByName(gunaComboBox2.SelectedItem.ToString());
            }
            if(gunaComboBox3.SelectedIndex!=0)
            {
                year = gunaComboBox3.SelectedItem.ToString();
            }

            if (gunaComboBox4.SelectedIndex != 0)
            {
                month = gunaComboBox4.SelectedIndex.ToString().PadLeft(2,'0');
            }

            if (gunaComboBox5.SelectedIndex != 0)
            {
                status = gunaComboBox5.SelectedItem.ToString();
            }

            ArrayList documents=documentsRepository.getDocumentsWith(owner,type, status,year,month);
            this.populateDocumentList(documents);
        }
    }
}
