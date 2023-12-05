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

namespace ProgBD { 

    public sealed partial class ViewEmployeesPage : Page
    {
        public ViewEmployeesPage()
        {
            this.InitializeComponent();

            // Creating hardcoded employee data for demonstration
            List<object> employees = new List<object>
            {
                new { FirstName = "John", LastName = "Doe", Position = "Manager", ImageUrl = "https://randomuser.me/api/portraits/lego/4.jpg"},
                new { FirstName = "Jane", LastName = "Smith", Position = "Developer",  ImageUrl = "https://randomuser.me/api/portraits/lego/0.jpg" },
                new { FirstName = "Alex", LastName = "Johnson", Position = "Designer", ImageUrl = "https://randomuser.me/api/portraits/lego/1.jpg" },
            };

            listeMateriel.ItemsSource = employees;
        }

        private void btCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEmployeesPage));
        }


    }
}
