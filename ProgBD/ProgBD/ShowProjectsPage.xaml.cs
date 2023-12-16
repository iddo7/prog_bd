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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgBD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowProjectsPage : Page
    {
        int index = -1;
        public ShowProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is not null)
            {
                try
                {
                    index = (int)e.Parameter;
                    Project project = (Project)ProjectSingleton.getInstance();

                    project_code.Text = project.Code ?? "N/A";
                    project_title.Text = project.Title;
                    project_startDate.DataContext = project.StartDate;
                    project_description.Text = project.Description;
                    project_budget.DataContext = project.Budget;
                    project_totalSalaries.DataContext = project.TotalSalaries;
                    project_client.DataContext = project.Client;
                    project_status.Text = project.Status;
                }
                catch
                {

                }
            }
        }
    }
}
