using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI.WinForms;

namespace RFID_Based_Document_Management.Classes
{
    class ImageApplier
    {
        public void Image(GunaButton button, Boolean isMinimumHeight, bool isWhiteIcon)
        {
            if (isMinimumHeight)
            {
                button.Image = isWhiteIcon ? global::RFID_Based_Document_Management.Properties.Resources.Sort_Up_50px_2 : global::RFID_Based_Document_Management.Properties.Resources.Sort_Up_50px;
            }
            else
            {
                button.Image = isWhiteIcon ? global::RFID_Based_Document_Management.Properties.Resources.Sort_Down_50px_1 : global::RFID_Based_Document_Management.Properties.Resources.Sort_Down_60px;
            }
        }
    }
}
