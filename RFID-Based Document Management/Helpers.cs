using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using RFID_Based_Document_Management.Library.Repositories;
using RFID_Based_Document_Management.Library.Models;

namespace RFID_Based_Document_Management
{
    class Helpers
    {

        public static void changeFolderInfoFromSelectedFolderType(GunaComboBox comboBox,GunaTextBox folderIdTxtBox,GunaTextBox folderNameTxtBox,FoldersRepository foldersRepository)
        {
            string folderType = comboBox.SelectedItem.ToString();
            folderIdTxtBox.Text = foldersRepository.getIdByName(folderType);
            folderNameTxtBox.Text = folderType;
        }
    
    }
}
