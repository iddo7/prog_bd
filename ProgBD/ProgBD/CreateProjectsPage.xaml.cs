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
using MySqlX.XDevAPI;

namespace ProgBD
{
    public sealed partial class CreateProjectsPage : Page
    {
        private Client selectedClient; // Déclaration de la variable au niveau de la classe


        public CreateProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Client client)
            {
                selectedClient = client; // Affectation du client sélectionné à la variable de la classe
            }
        }


        private async void btAjouterProject_Click(object sender, RoutedEventArgs e)
        {
            Project project = new Project();
            bool verification_project = true;

            /*            
            */
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

            if (selectedClient == null) return;

            project.Client = selectedClient;

            if (!verification_project) return;



            bool actionSucceeded = ProjectSingleton.Instance().Create(project);

            /*   --- FEEDBACK ---   */
            string dialogTitle;
            string dialogContent;
            if (actionSucceeded)
            {
                dialogTitle = "Projet ajoute";
                dialogContent = $"Le projet {project.Title} a bien ete ajoute";
            }
            else
            {
                dialogTitle = Dialog.DefaultErrorTitle;
                dialogContent = Dialog.DefaultErrorContent;
            }
            await Dialog.VoidDialog(dialogTitle, dialogContent);

            if (!actionSucceeded) return;
            Frame.Navigate(typeof(ViewProjectsPage));
        }


    }
}
