using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ProgBD
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            WindowSingleton.Instance().MainWindow = this;
            WindowSingleton.Instance().DialogPanel = dialogPanel;
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = args.SelectedItem as NavigationViewItem;

            switch (item.Name)
            {
                case "navClients":
                    mainFrame.Navigate(typeof(ViewClientsPage));
                    break;
                case "navProjects":
                    mainFrame.Navigate(typeof(ViewProjectsPage));
                    break;
                case "navEmployees":
                    mainFrame.Navigate(typeof(ViewEmployeesPage));
                    break;
                default:
                    break;

            }
        }


    }
}
