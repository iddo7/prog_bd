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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string a;
        public MainWindow()
        {
            this.InitializeComponent();
            ObservableCollection<Project> clients = ProjectSingleton.Instance().List();

            
            foreach (Project client in clients)
            {
                a = client.ToString();
            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {

            Client client = new Client(
                201,
                "Isaac Negreiros",
                "123 rue Test",
                "(873) 266-7053",
                "isaacnegreiros11@gmail.com"
            );

            ClientSingleton.Instance().Create( client );
            myButton.Content = client.ToString();
        }
    }
}
