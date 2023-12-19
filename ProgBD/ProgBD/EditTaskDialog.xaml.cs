using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySqlX.XDevAPI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    public sealed partial class EditTaskDialog : ContentDialog
    {
        public EditTaskDialog()
        {
            this.InitializeComponent();
        }

        public EditTaskDialog(double hoursWorked)
        {
            this.InitializeComponent();
            input_hoursWorked.Text = hoursWorked.ToString();
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Task task = new();
            bool verificationTask = true;



            try
            {
                task.HoursWorked = double.Parse(input_hoursWorked.Text);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_hoursWorked, true);
                verificationTask = false;
            }
            if (!verificationTask) return;

/*            bool actionSucceeded = TaskSingleton.Instance().Edit(projectCode.Id, employe, client);
*/

            /*   --- FEEDBACK ---   */

        }       



    }
}
