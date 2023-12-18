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
using System.Reflection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditClientsPage : Page
    {
        Client shownClient;

        public EditClientsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            shownClient = (Client)e.Parameter;

            input_client_address.Text = shownClient.Address;
            input_client_email.Text = shownClient.Email;
            input_client_fullName.Text = shownClient.FullName;
            input_client_phoneNumber.Text = shownClient.PhoneNumber;
        }

        private async void btConfirmEditClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            bool verification_client = true;

            try
            {
                client.FullName = input_client_fullName.Text;
                Utilities.SetVisibility(alert_client_fullName, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_client_fullName, true);
                verification_client = false;
            }

            try
            {
                client.Address = input_client_address.Text;
                Utilities.SetVisibility(alert_client_address, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_client_address, true);
                verification_client = false;
            }

            try
            {
                client.PhoneNumber = input_client_phoneNumber.Text;
                Utilities.SetVisibility(alert_client_phoneNumber, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_client_phoneNumber, true);
                verification_client = false;
            }

            try
            {
                client.Email = input_client_email.Text;
                Utilities.SetVisibility(alert_client_email, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_client_email, true);
                verification_client = false;
            }

            if (!verification_client) return;

            bool actionSucceeded = ClientSingleton.Instance().Edit(shownClient.Id, client);


            /*   --- FEEDBACK ---   */
            string dialogTitle;
            string dialogContent;
            if (actionSucceeded)
            {
                dialogTitle = "Client modifié";
                dialogContent = $"Le client {client.FullName} a bien été modifié";
            }
            else
            {
                dialogTitle = Dialog.DefaultErrorTitle();
                dialogContent = Dialog.DefaultErrorContent();
            }
            await Dialog.VoidDialog(dialogTitle, dialogContent);

            if (!actionSucceeded) return;
            Frame.Navigate(typeof(ViewClientsPage));
        }
    }
}
