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
    public sealed partial class LoginDialog : ContentDialog
    {
        public LoginDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Admin admin = new Admin();
            bool verificationAdmin = true;

            try
            {
                admin.Username = input_username.Text;
                Utilities.SetVisibility(alert_username, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_username, true);
                verificationAdmin = false;
            }

            try
            {
                admin.Password = input_password.Password;
                Utilities.SetVisibility(alert_password, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_password, true);
                verificationAdmin = false;
            }

            bool loginSuccess = false;
            if (verificationAdmin)
            {
                loginSuccess = AuthSingleton.Instance().Login(admin.Username, Utilities.HashSHA256(admin.Password));
                AuthSingleton.Instance().SetConnection(loginSuccess);
                Utilities.SetVisibility(alert_login, !loginSuccess);
            }
            args.Cancel = !(loginSuccess && verificationAdmin); // Only close dialog if logged
        }
    }
}
