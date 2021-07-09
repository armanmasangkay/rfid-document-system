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
using Bunifu.Framework.UI;
using BunifuAnimatorNS;

namespace RFID_Based_Document_Management.Classes
{
    class Animator
    {

        GunaAnimateWindow windowAnimator = new GunaAnimateWindow();
        GunaTransition transition = new GunaTransition();
        ImageApplier apply = new ImageApplier();
        Checker checker = new Checker();

        public void AnimateDropDownPanel(GunaLinePanel gunaLinePanel, GunaButton button, Boolean isWhiteIcon)
        {
            transition.TimeStep = 0.03f;
            transition.AnimationType = Guna.UI.Animation.AnimationType.VertBlind;

            if (checker.IsToggledToMinimumHeight(gunaLinePanel))
            {
                apply.Image(button, true, isWhiteIcon);

                gunaLinePanel.Visible = false;
                gunaLinePanel.Height = gunaLinePanel.MaximumSize.Height;
                transition.ShowSync(gunaLinePanel);
            }
            else if (checker.IsToggledToMaximumHeight(gunaLinePanel))
            {
                apply.Image(button, false, isWhiteIcon);

                gunaLinePanel.Visible = true;
                transition.HideSync(gunaLinePanel);
                gunaLinePanel.Height = gunaLinePanel.MinimumSize.Height;
            }
        }

        public void AnimateWindow(Form form)
        {
            windowAnimator.TargetControl = form;
            windowAnimator.AnimationType = GunaAnimateWindow.AnimateWindowType.AW_CENTER;
            windowAnimator.Start();
        }


    }
}
