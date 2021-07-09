using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace RFID_Based_Document_Management.Classes
{
    class RenderStyling
    {
        public void BackgroundColor(GunaButton button, Color color)
        {
            button.BaseColor = color;
        }

        public void ForeColor(GunaButton button, Color color)
        {
            button.ForeColor = color;
        }

        public void BorderColor(GunaButton button, Color color)
        {
            button.BorderColor = color;
        }

        public void FormText(Form form, string text)
        { 
            form.Text = "Document Management RFID-Based IT System - " + text;
        }

        public void LabelText(GunaLabel label, string text)
        {
            label.Text = "USER DASHBOARD - " + text;
        }
    }
}
