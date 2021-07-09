using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace RFID_Based_Document_Management.Classes
{
    class ControlRenderer
    {
        public void Render(Panel panel, UserControl user)
        {
            panel.Controls.Clear();

            user.Dock = DockStyle.Fill;
            user.BringToFront();
            panel.Controls.Add(user);
        }
    }
}
