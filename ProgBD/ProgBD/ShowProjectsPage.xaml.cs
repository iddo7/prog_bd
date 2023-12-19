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
            shownProject = (Project)e.Parameter;

            UpdateLists();

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
            if (!AuthSingleton.Instance().IsConnected())
            {
                Dialog.NotLoggedDialog();
                return;
            }
            Frame.Navigate(typeof(EditProjectsPage), shownProject);
        }

        private void listeTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task task = listeTasks.SelectedItem as Task;
            if (task == null) return;

            Dialog.EditTaskDialog(task.ProjectCode, task.EmployeeCode, task.HoursWorked);
        }

        private async void btAssignEmployeeToProject_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)listUnassignedEmployees.SelectedItem;

            if (selectedEmployee == null) return;
            if (shownProject.Status == "Terminé")
            {
                await Dialog.VoidDialog("Creation tache", "Ce projet est terminé, vous ne pouvez pas y ajouter des taches.");
                return;
            }
            int numberOfTasks = TaskSingleton.Instance().TasksFromProject(shownProject.Code).Count;
            if (numberOfTasks >= shownProject.NumberOfEmployees)
            {
                await Dialog.VoidDialog("Creation tache", "Ce projet a deja atteint son nombre d'employes.");
                return;
            }

            Task task = new(shownProject.Code, selectedEmployee.Code);

            TaskSingleton.Instance().Create(task);
            UpdateLists();
        }

        public void UpdateLists()
        {
            TaskSingleton.Instance().UpdateLocalList();
            listeTasks.ItemsSource = TaskSingleton.Instance().TasksFromProject(shownProject.Code);
            listUnassignedEmployees.ItemsSource = EmployeeSingleton.Instance().UnassignedEmployees();
        }
    }
}
