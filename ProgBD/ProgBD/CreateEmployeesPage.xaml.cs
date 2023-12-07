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
    public sealed partial class CreateEmployeesPage : Page
    {
        public CreateEmployeesPage()
        {
            this.InitializeComponent();
        }


        private void btAjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();

            bool verification_employee = true;

            try
            {
                employee.FirstName = input_employee_firstName.Text;
                verification_input(alert_employee_firstName, false);
            }
            catch (Exception ex)
            {
                verification_input(alert_employee_firstName, true); ;
                verification_employee = false;
            }

            try
            {
                employee.LastName = input_employee_lastName.Text;
                verification_input(alert_employee_lastName, false);
            }
            catch (Exception ex)
            {
                verification_input(alert_employee_lastName, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Address = input_employee_address.Text;
                verification_input(alert_employee_address, false);
            }
            catch (Exception ex)
            {
                verification_input(alert_employee_address, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Email = input_employee_email.Text;
                verification_input(alert_employee_email, false);

            }
            catch (Exception ex)
            {
                verification_input(alert_employee_email, true); ;
                verification_employee = false;
            }

            try
            {
                employee.ProfilePicture = new Uri(input_employee_profilePicture.Text);
                verification_input(alert_employee_profilePicture, false);

            }
            catch (Exception ex)
            {
                verification_input(alert_employee_profilePicture, true); ;
                verification_employee = false;
            }

            try
            {
                employee.HourlyRate = double.Parse(input_employee_hourlyRate.Text);
                verification_input(alert_employee_hourlyRate, false);

            }
            catch (Exception ex)
            {
                verification_input(alert_employee_hourlyRate, true); ;
                verification_employee = false;
            }

            try
            {
                employee.HiringDate = input_employee_hiringDate.Date.DateTime;
                verification_input(alert_employee_hiringDate, false);
            }
            catch (Exception ex)
            {
                verification_input(alert_employee_hiringDate, true); ;
                verification_employee = false;
            }

            try
            {
                employee.Birthday = input_employee_birthday.Date.DateTime;
                verification_input(alert_employee_birthday, false);

            }
            catch (Exception ex)
            {
                verification_input(alert_employee_birthday, true); ;
                verification_employee = false;
            }

            if (!verification_employee) return;
        }

        private void verification_input(UIElement element, bool state)
        {
            if (state)
                element.Visibility = Visibility.Visible;
            else 
                element.Visibility = Visibility.Collapsed;
        }

    }
}
