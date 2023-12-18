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
    public sealed partial class CreateEmployeesPage : Page
    {
        public CreateEmployeesPage()
        {
            this.InitializeComponent();
        }


        private async void btAjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            /*   --- Checks ---   */

            Employee employee = new Employee();
            bool verification_employee = true;


            try
            {
                employee.FirstName = input_employee_firstName.Text;
                Utilities.SetVisibility(alert_employee_firstName, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_firstName, true);
                verification_employee = false;
            }

            try
            {
                employee.LastName = input_employee_lastName.Text;
                Utilities.SetVisibility(alert_employee_lastName, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_lastName, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Address = input_employee_address.Text;
                Utilities.SetVisibility(alert_employee_address, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_address, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Email = input_employee_email.Text;
                Utilities.SetVisibility(alert_employee_email, false);

            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_email, true); ;
                verification_employee = false;
            }

            try
            {
                employee.ProfilePicture = new Uri(input_employee_profilePicture.Source.ToString());
                Utilities.SetVisibility(alert_employee_profilePicture, false);

            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_profilePicture, true); ;
                verification_employee = false;
            }

            try
            {
                employee.HourlyRate = double.Parse(input_employee_hourlyRate.Text);
                Utilities.SetVisibility(alert_employee_hourlyRate, false);

            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_hourlyRate, true); ;
                verification_employee = false;
            }

            try
            {
                employee.HiringDate = input_employee_hiringDate.Date.DateTime;
                Utilities.SetVisibility(alert_employee_hiringDate, false);
            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_hiringDate, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Birthday = input_employee_birthday.Date.DateTime;
                Utilities.SetVisibility(alert_employee_birthday, false);

            }
            catch (Exception ex)
            {
                Utilities.SetVisibility(alert_employee_birthday, true); ;
                verification_employee = false;
            }

            if (!verification_employee) return;


            bool actionSucceeded = EmployeeSingleton.Instance().Create(employee);


            /*   --- FEEDBACK ---   */
            string dialogTitle;
            string dialogContent;
            if (actionSucceeded)
            {
                dialogTitle = "Employe ajoute";
                dialogContent = $"L'employe {employee.FirstName} {employee.LastName} a bien ete ajoute";
            }
            else
            {
                dialogTitle = Dialog.DefaultErrorTitle();
                dialogContent = Dialog.DefaultErrorContent();
            }
            await Dialog.VoidDialog(dialogTitle, dialogContent);

            if (!actionSucceeded) return;
            Frame.Navigate(typeof(ViewEmployeesPage));

        }

    }
}
