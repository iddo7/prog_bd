using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    public sealed partial class CreateAdminDialog : ContentDialog
    {
        public CreateAdminDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Admin admin = new Admin();
            bool verificationAdmin = true;

            Utilities.SetVisibility(alert_username, false);
            Utilities.SetVisibility(alert_password, false);
            Utilities.SetVisibility(alert_repeat_password, false);

            try
            {
                admin.Username = input_username.Text;
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_username, true);
                verificationAdmin = false;
            }

            try
            {
                admin.Password = input_password.Password;
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_password, true);
                verificationAdmin = false;
            }

            if (input_repeat_password.Password != admin.Password || input_repeat_password.Password == string.Empty)
            {
                Utilities.SetVisibility(alert_repeat_password, true);
                verificationAdmin = false;
            }

            bool actionSucceeded = false;
            if (verificationAdmin)
            {
                actionSucceeded = AuthSingleton.Instance().Create(admin);
            }

            args.Cancel = !(actionSucceeded && verificationAdmin); // Only close dialog if created admin

        }
    }
}
