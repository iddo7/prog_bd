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

        bool verification_employee = true;

        private void btAjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();


            try
            {
                employee.FirstName = input_employee_firstName.Text;
            }
            catch (Exception ex)
            {
                alert_employee_firstName.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                employee.LastName = input_employee_lastName.Text;
            }
            catch (Exception ex)
            {
                alert_employee_lastName.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                employee.Address = input_employee_address.Text;
            }
            catch (Exception ex)
            {
                alert_employee_address.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                employee.Email = input_employee_email.Text;
            }
            catch (Exception ex)
            {
                alert_employee_email.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                employee.ProfilePicture = new Uri(input_employee_profilePicture.Text); // Assuming a property exists for profile picture
            }
            catch (Exception ex)
            {
                alert_employee_profilePicture.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                // Parse the hourly rate from input_employee_hourlyRate.Text and assign it to employee.HourlyRate
                employee.HourlyRate = double.Parse(input_employee_hourlyRate.Text);
            }
            catch (Exception ex)
            {
                alert_employee_hourlyRate.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                // Parse the hiring date from input_employee_hiringDate.Text and assign it to employee.HiringDate
                employee.HiringDate = DateTime.Parse(input_employee_hiringDate.Text);
            }
            catch (Exception ex)
            {
                alert_employee_hiringDate.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            try
            {
                // Parse the birthday from input_employee_birthday.Text and assign it to employee.Birthday
                employee.Birthday = DateTime.Parse(input_employee_birthday.Text);
            }
            catch (Exception ex)
            {
                alert_employee_birthday.Visibility = Visibility.Visible;
                verification_employee = false;
            }

            if (!verification_employee) return;
        }

    }
}
