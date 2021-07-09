using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace RFID_Based_Document_Management.Classes
{
    class DragForm
    {
        GunaDragControl dragForm = new GunaDragControl();

        public void Drag(Form form)
        {
            dragForm.TargetControl = form;
        }
    }
}
