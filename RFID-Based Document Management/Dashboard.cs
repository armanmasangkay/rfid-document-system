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

namespace RFID_Based_Document_Management
{
    public partial class Dashboard : Form
    {
        private Classes.Animator animator = new Classes.Animator();
        private Classes.DropShadow dropShadow = new Classes.DropShadow();
        private Classes.DragForm dragForm = new Classes.DragForm();
        private Classes.ControlRenderer control = new Classes.ControlRenderer();
        private Classes.RenderStyling render = new Classes.RenderStyling();

        private OverviewControl ovrView = new OverviewControl();
        private Document_Entry docEntry = new Document_Entry();
        private Return_Document returnDoc = new Return_Document();
        private Document_Lists docLists = new Document_Lists();
        private User_Account user = new User_Account();

        public Dashboard()
        {
            InitializeComponent();

            this.animator.AnimateWindow(this);
            this.dragForm.Drag(this);
            this.dropShadow.RenderShadows(this);

            this.applyButtonStyling(gunaButton5, gunaButton6, gunaButton1, gunaButton2);
            this.control.Render(panel3, ovrView);
            this.render.FormText(this, "Overview");
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
            animator.AnimateDropDownPanel(gunaLinePanel1, gunaButton10, false);
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            this.applyButtonStyling(gunaButton5, gunaButton6, gunaButton1, gunaButton2);
            this.control.Render(panel3, ovrView);
            this.render.FormText(this, "Overview");
            this.render.LabelText(gunaLabel2, "OVERVIEW");
        }

        private void applyButtonStyling(GunaButton btn1, GunaButton btn2, GunaButton btn3, GunaButton btn4)
        {

            this.renderButtonStyle(btn1, System.Drawing.Color.FromArgb(86, 129, 63), 
                                   System.Drawing.Color.White,
                                   System.Drawing.Color.FromArgb(86, 129, 63));

            this.renderButtonStyle(btn2, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));

            this.renderButtonStyle(btn3, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));

            this.renderButtonStyle(btn4, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));
        }

        private void removeButtonStyling(GunaButton btn1, GunaButton btn2, GunaButton btn3, GunaButton btn4)
        {

            this.renderButtonStyle(btn1, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));

            this.renderButtonStyle(btn2, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));

            this.renderButtonStyle(btn3, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));

            this.renderButtonStyle(btn4, System.Drawing.Color.White,
                                   System.Drawing.Color.DimGray,
                                   System.Drawing.Color.FromArgb(224, 224, 224));
        }

        private void renderButtonStyle(GunaButton btn, Color bg_color, Color fg_color, Color br_color)
        {
            this.render.BackgroundColor(btn, bg_color);
            this.render.ForeColor(btn, fg_color);
            this.render.BorderColor(btn, br_color);
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            this.applyButtonStyling(gunaButton6, gunaButton5, gunaButton1, gunaButton2);
            this.control.Render(panel3, docEntry);
            this.render.FormText(this, "Document Entry");
            this.render.LabelText(gunaLabel2, "ADDING OR DOCUMENT ENTRY");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.applyButtonStyling(gunaButton1, gunaButton5, gunaButton6, gunaButton2);
            this.control.Render(panel3, returnDoc);
            this.render.FormText(this, "Return Document");
            this.render.LabelText(gunaLabel2, "SCANNING AND RETURNING DOCUMENT");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.applyButtonStyling(gunaButton2, gunaButton5, gunaButton6, gunaButton1);
            this.control.Render(panel3, docLists);
            this.render.FormText(this, "Lists Of Document");
            this.render.LabelText(gunaLabel2, "DOCUMENTS LIST");
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            this.removeButtonStyling(gunaButton1, gunaButton2, gunaButton6, gunaButton5);

            this.control.Render(panel3, user);
            this.render.FormText(this, "User Accounts");
            this.render.LabelText(gunaLabel2, "SYSTEM USER ACCOUNTS");
            this.animator.AnimateDropDownPanel(gunaLinePanel1, gunaButton10, false);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
