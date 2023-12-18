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

namespace ProgBD { 

    public sealed partial class ViewEmployeesPage : Page
    {
        public ViewEmployeesPage()
        {
            this.InitializeComponent();
            listeEmployees.ItemsSource = EmployeeSingleton.Instance().List();
        }

        private void btCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!AuthSingleton.Instance().IsConnected())
            {
                Dialog.NotLoggedDialog();
                return;
            }
            Frame.Navigate(typeof(CreateEmployeesPage));
        }

        private void listeEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeEmployees.SelectedIndex >= 0)
            {
                Employee selectedEmployee = (Employee) listeEmployees.SelectedItem;
                if (selectedEmployee == null) return;

                this.Frame.Navigate(typeof(ShowEmployeesPage), selectedEmployee);
            }
        }
    }
}
