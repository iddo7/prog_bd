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
    public sealed partial class ViewProjectsPage : Page
    {
        public ViewProjectsPage()
        {
            this.InitializeComponent();
            listeProjects.ItemsSource = ProjectSingleton.Instance().List();
        }


        private void listeProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeProjects.SelectedIndex >= 0)
            {
                this.Frame.Navigate(typeof(ShowProjectsPage), listeProjects.SelectedIndex);

            }
        }

        private async void btExportEmployees_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            List<Project> list = ProjectSingleton.Instance().List().ToList();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(WindowSingleton.Instance().MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            Windows.Storage.StorageFile exportFile = await picker.PickSaveFileAsync();
            if (exportFile == null) return;

            await Windows.Storage.FileIO.WriteLinesAsync(exportFile, list.ConvertAll(project => project.ToCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }

        private void btCreateProject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateProjectsPage));
        }

    }
}
