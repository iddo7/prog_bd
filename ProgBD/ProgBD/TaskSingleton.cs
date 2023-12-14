
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProgBD
{
    internal class TaskSingleton
    {
        MySqlConnection conn;
        ObservableCollection<Task> list;
        static TaskSingleton instance = null;

        public TaskSingleton()
        {
            list = new ObservableCollection<Task>();
            conn = new MySqlConnection(BdConnexionInfo.ConnectionString());
        }

        public static TaskSingleton Instance()
        {
            if (instance == null) instance = new TaskSingleton();
            return instance;
        }

        public ObservableCollection<Task> List()
        {
            UpdateLocalList();
            return list;
        }

        public Task Task(int index)
        {
            return (Task)list[index];
        }

        public bool Create(Task task)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_assign_employee_to_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_projectCode", task.ProjectCode);
                cmd.Parameters.AddWithValue("_employeeCode", task.EmployeeCode);
                cmd.Parameters.AddWithValue("_hoursWorked", task.HoursWorked);

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
                conn.Close();
            }
            catch (MySqlException mse)
            {
                conn.Close();
                success = false;
            }

            if (success) UpdateLocalList();
            return success;
        }

        public bool Edit(string projectCode, string employeeCode, Task updatedTask)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_update_employee_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_projectCode", projectCode);
                cmd.Parameters.AddWithValue("_employeeCode", employeeCode);
                cmd.Parameters.AddWithValue("_hoursWorked", updatedTask.HoursWorked);
                cmd.Parameters.AddWithValue("_salary", updatedTask.Salary);


                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
                conn.Close();
            }
            catch (MySqlException mse)
            {
                conn.Close();
                success = false;
            }

            if (success) UpdateLocalList();
            return success;
        }

        public bool Destroy(string projectCode, string employeeCode)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_employee_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_projectCode", projectCode);
                cmd.Parameters.AddWithValue("_employeeCode", employeeCode);

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery(); // Check i value
                conn.Close();
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
            ClearLocalList();

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_select_projects_employees");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    string projectCode = (string)reader["projectCode"];
                    string employeeCode = (string)reader["employeeCode"];
                    double hoursWorked = (double)reader["hoursWorked"];
                    double salary = (double)reader["salary"];

                    Task task = new Task
                    (
                        projectCode,
                        employeeCode,
                        hoursWorked,
                        salary
                    );

                    list.Add(task);
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
