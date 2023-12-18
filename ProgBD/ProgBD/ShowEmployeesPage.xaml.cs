using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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
    public sealed partial class ShowEmployeesPage : Page
    {
        Employee shownEmployee;

        public ShowEmployeesPage()
        {
            this.InitializeComponent();
        }

        private void btModifyEmployee_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditEmployeesPage), shownEmployee);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            shownEmployee = (Employee)e.Parameter;

            // employee_profilePicture
            employee_firstName.Text = shownEmployee.FirstName;
            employee_lastName.Text = shownEmployee.LastName;
            employee_code.Text = shownEmployee.Code;
            employee_email.Text = shownEmployee.Email;
            employee_hiringDate.Text = shownEmployee.HiringDate.ToString("MMMM dd, yyyy");
            employee_birthday.Text = shownEmployee.Birthday.ToString("MMMM dd, yyyy");
            employee_address.Text = shownEmployee.Address;
            employee_hourlyRate.Text = shownEmployee.HourlyRate.ToString() + "$";
            employee_status.Text = shownEmployee.Status;
            employee_profilePicture.Source = new BitmapImage(new Uri(shownEmployee.ProfilePicture.ToString(), UriKind.RelativeOrAbsolute));
        }
    }
}
