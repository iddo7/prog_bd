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

namespace ProgBD
{
    public sealed partial class ShowClientsPage : Page
    {
        Client shownClient;

        public ShowClientsPage()
        {
            this.InitializeComponent();
        }


        private void btModifyClient_Click(object sender, RoutedEventArgs e)
        {
            if (!AuthSingleton.Instance().IsConnected())
            {
                Dialog.NotLoggedDialog();
                return;
            }
            Frame.Navigate(typeof(EditClientsPage), shownClient);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            shownClient = (Client) e.Parameter;

            client_id.Text = shownClient.Id.ToString();
            client_address.Text = shownClient.Address;
            client_email.Text = shownClient.Email;
            client_fullName.Text = shownClient.FullName;
            client_phoneNumber.Text = shownClient.PhoneNumber;
        }
    }
}
