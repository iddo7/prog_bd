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
    public sealed partial class ViewProjectsPage : Page
    {
        public ViewProjectsPage()
        {
            this.InitializeComponent();

            // Creating hardcoded employee data for demonstration
            List<object> projects = new List<object>
            {
                new { code = "123", title = "project1", startDate = "3 décembre 2023", budget = "10$", status = "En cours.." },
                new { code = "123", title = "project1", startDate = "3 décembre 2023", budget = "10$", status = "En cours.." },
                new { code = "123", title = "project1", startDate = "3 décembre 2023", budget = "10$", status = "En cours.." },
            };

            listeMateriel.ItemsSource = projects;
        }

        private void btCreateProject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateProjectsPage));
        }
    }
}
