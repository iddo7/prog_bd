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

namespace ProgBD
{
    public sealed partial class ViewClientsPage : Page
    {
        public ViewClientsPage()
        {
            this.InitializeComponent();
            listeClients.ItemsSource = ClientSingleton.Instance().List();
        }

        private void btCreateClient_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateClientsPage)); 
        }

        private void listeClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeClients.SelectedIndex >= 0)
            {
                this.Frame.Navigate(typeof(ShowClientsPage), listeClients.SelectedIndex);

            }
        }
    }
}
