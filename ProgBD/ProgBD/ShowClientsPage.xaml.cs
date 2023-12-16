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
        Client showedClient;
        public ShowClientsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            showedClient = (Client) e.Parameter;
            if (showedClient == null) return;

            client_id.Text = showedClient.Id.ToString();
            client_address.Text = showedClient.Address;
            client_email.Text = showedClient.Email;
            client_fullName.Text = showedClient.FullName;
            client_phoneNumber.Text = showedClient.PhoneNumber;
        }
    }
}
