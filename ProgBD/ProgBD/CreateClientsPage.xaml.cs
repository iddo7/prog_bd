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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateClientsPage : Page
    {
        public CreateClientsPage()
        {
            this.InitializeComponent();
        }

        bool verification_client = true;

        private void btAjouterClient_Click(object sender, RoutedEventArgs e)
        {
            alert_client_email.Visibility = Visibility.Visible;
            Client client = new Client();

            try 
            {
                client.FullName = input_client_fullName.Text;
            } 
            catch (Exception a)
            { 
                alert_client_fullName.Visibility = Visibility.Visible;
                verification_client = false;
            }

            try
            {
                client.Address = input_client_address.Text;
            }
            catch (Exception a)
            {
                alert_client_address.Visibility = Visibility.Visible;
                verification_client = false;
            }

            try
            {
                client.PhoneNumber = input_client_phoneNumber.Text;
            }
            catch (Exception a)
            {
                alert_client_phoneNumber.Visibility = Visibility.Visible;
                verification_client = false;
            }

            try
            {
                client.Email = input_client_email.Text;
            }
            catch (Exception a)
            {
                alert_client_email.Visibility = Visibility.Visible;
                verification_client = false;
            }

            if (!verification_client) return;

        }
    }

    /*clients = new clients 

        try (
        clients = eded.text)

        catch(
        erreur ) */
}
