using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ProgBD
{
    public sealed partial class ShowProjectsPage : Page
    {
        Project shownProject;

        public ShowProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            shownProject = (Project) e.Parameter;

            project_code.Text = shownProject.Code;
            project_title.Text = shownProject.Title;
            project_description.Text = shownProject.Description;
            project_budget.Text = shownProject.Budget.ToString() + "$";
            project_startDate.Text = shownProject.StartDate.ToString("MMMM dd, yyyy");
            project_client.Text = shownProject.Client.FullName;
            project_status.Text = shownProject.Status;
            project_totalSalaries.Text = shownProject.TotalSalaries.ToString() + "$";
        }

        private void btModifyProjects_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditProjectsPage), shownProject);
        }
    }
}
