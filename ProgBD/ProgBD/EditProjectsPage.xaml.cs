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
    public sealed partial class EditProjectsPage : Page
    {
        Project shownProject;
        public EditProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            shownProject = (Project)e.Parameter;

            input_project_title.Text = shownProject.Title;
            input_project_description.Text = shownProject.Description;
            input_project_budget.Text = shownProject.Budget.ToString("0.00");
            input_project_startDate.DataContext = shownProject.StartDate;
            input_project_numberOfEmployees.Text = shownProject.NumberOfEmployees.ToString("0");


        }

        private void btConfirmEditProject_Click(object sender, RoutedEventArgs e)
        {
            Project project = new Project();
            bool verification_project = true;

            try
            {
                project.Title = input_project_title.Text;
                Utilities.SetVisibility(alert_project_title, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_project_title, true);
                verification_project = false;
            }

            try
            {
                project.StartDate = input_project_startDate.Date.DateTime;
                Utilities.SetVisibility(alert_project_startDate, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_project_startDate, true);
                verification_project = false;
            }

            try
            {
                project.Description = input_project_description.Text;
                Utilities.SetVisibility(alert_project_description, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_project_description, true);
                verification_project = false;
            }

            try
            {
                project.Budget = double.Parse(input_project_budget.Text);
                Utilities.SetVisibility(alert_project_budget, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_project_budget, true);
                verification_project = false;
            }

            try
            {
                project.NumberOfEmployees = int.Parse(input_project_numberOfEmployees.Text);
                Utilities.SetVisibility(alert_project_numberOfEmployees, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_project_numberOfEmployees, true);
                verification_project = false;
            }


            if (!verification_project) return;
        }
    }
}
