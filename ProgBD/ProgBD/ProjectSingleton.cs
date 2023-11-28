using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class ProjectSingleton
    {
        MySqlConnection conn;
        ObservableCollection<Project> list;
        static ProjectSingleton instance = null;

        public ProjectSingleton()
        {
            list = new ObservableCollection<Project>();
            conn = new MySqlConnection(BdConnexionInfo.ConnectionString());
        }

        public static ProjectSingleton Instance()
        {
            if (instance == null) instance = new ProjectSingleton();
            return instance;
        }

        public ObservableCollection<Project> List()
        {
            UpdateLocalList();
            return list;
        }

        public Project Project(int index)
        {
            return (Project)list[index];
        }

        public bool Create(Project project)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_insert_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_title", project.Title);
                cmd.Parameters.AddWithValue("_startDate", project.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_description", project.Description);
                cmd.Parameters.AddWithValue("_budget", project.Budget);
                cmd.Parameters.AddWithValue("_numberOfEmployees", project.NumberOfEmployees);
                cmd.Parameters.AddWithValue("_totalSalaries", project.TotalSalaries);
                cmd.Parameters.AddWithValue("_client", project.Client.Id);

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
            }
            catch (MySqlException mse)
            {
                conn.Close();
                success = false;
            }

            if (success) UpdateLocalList();
            return success;
        }

        public bool Edit(int projectId, Project updatedProject)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_update_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_employeeCode", projectId);
                cmd.Parameters.AddWithValue("_title", updatedProject.Title);
                cmd.Parameters.AddWithValue("_startDate", updatedProject.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_description", updatedProject.Description);
                cmd.Parameters.AddWithValue("_budget", updatedProject.Budget);
                cmd.Parameters.AddWithValue("_numberOfEmployees", updatedProject.NumberOfEmployees);
                cmd.Parameters.AddWithValue("_totalSalaries", updatedProject.TotalSalaries);
                cmd.Parameters.AddWithValue("_client", updatedProject.Client.Id);


                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
            }
            catch (MySqlException mse)
            {
                conn.Close();
                success = false;
            }

            if (success) UpdateLocalList();
            return success;
        }

        public bool Destroy(int projectId)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_code", projectId);

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
            }
            catch (MySqlException mse)
            {
                conn.Close();
                success = false;
            }

            if (success) UpdateLocalList();
            return success;
        }


        public void UpdateLocalList()
        {
            list.Clear();

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_select_projects");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                ClientSingleton.Instance().UpdateLocalList();
                while (reader.Read())
                {
                    string projectCode = (string)reader["code"];
                    string title = (string)reader["title"];
                    DateTime startDate = (DateTime)reader["startDate"];
                    string description = (string)reader["description"];
                    double budget = (double)reader["budget"];
                    int numberOfEmployees = (int)reader["numberOfEmployees"];
                    double totalSalaries = (double)reader["totalSalaries"];
                    int clientId = (int)reader["clientId"];
                    string status = (string)reader["status"];

                    Client clientAttached = ClientSingleton.Instance().Client(clientId);
                    

                    Project project = new Project
                    (
                        projectCode,
                        title,
                        startDate,
                        description,
                        budget,
                        numberOfEmployees,
                        totalSalaries,
                        clientAttached,
                        status
                    );

                    list.Add(project);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException mse)
            {
                conn.Close();
            }

        }

        public void ClearLocalList()
        {
            list.Clear();
        }
    }
}
