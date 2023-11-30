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
    public sealed partial class ViewClientsPage : Page
    {
        public ViewClientsPage()
        {
            this.InitializeComponent();

            // Creating hardcoded employee data for demonstration
            List<object> clients = new List<object>
            {
                new { FirstName = "John", LastName = "Doe", Adress = "134 Ave. Park", phoneNumber = "123-456-7890", Email = "johndoe@gmail.com" },
                new { FirstName = "John", LastName = "Doe", Adress = "134 Ave. Park", phoneNumber = "123-456-7890", Email = "johndoe@gmail.com" },
                new { FirstName = "John", LastName = "Doe", Adress = "134 Ave. Park", phoneNumber = "123-456-7890", Email = "johndoe@gmail.com" },
            };

            listeMateriel.ItemsSource = clients;
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateClientsPage)); 
        }
    }
}
