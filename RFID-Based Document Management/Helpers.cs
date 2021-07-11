using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using RFID_Based_Document_Management.Library.Repositories;

namespace RFID_Based_Document_Management
{
    class Helpers
    {

        public static void changeFolderInfoFromSelectedFolderType(GunaComboBox comboBox,GunaTextBox folderIdTxtBox,GunaTextBox folderNameTxtBox,FoldersRepository foldersRepository)
        {
            string folderType = comboBox.SelectedItem.ToString();
            folderIdTxtBox.Text = folderType;
            folderNameTxtBox.Text = foldersRepository.getNameById(folderType);
        }
    }
}
