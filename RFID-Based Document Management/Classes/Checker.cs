using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace RFID_Based_Document_Management.Classes
{
    class Checker
    {
        public bool IsToggledToMinimumHeight(GunaLinePanel gunaLinePanel)
        {
            return (gunaLinePanel.Height == gunaLinePanel.MinimumSize.Height);
        }

        public bool IsToggledToMaximumHeight(GunaLinePanel gunaLinePanel)
        {
            return (gunaLinePanel.Height == gunaLinePanel.MaximumSize.Height);
        }
    }
}
