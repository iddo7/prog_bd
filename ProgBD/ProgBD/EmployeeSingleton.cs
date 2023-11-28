
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProgBD
{
    internal class EmployeeSingleton
    {
        MySqlConnection conn;
        ObservableCollection<Employee> list;
        static EmployeeSingleton instance = null;

        public EmployeeSingleton()
        {
            list = new ObservableCollection<Employee>();
            conn = new MySqlConnection(BdConnexionInfo.ConnectionString());
        }

        public static EmployeeSingleton Instance()
        {
            if (instance == null) instance = new EmployeeSingleton();
            return instance;
        }

        public ObservableCollection<Employee> List()
        {
            UpdateLocalList();
            return list;
        }

        public Employee Employee(int index)
        {
            return (Employee)list[index];
        }

        public bool Create(Employee employee)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_insert_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_firstName", employee.FirstName);
                cmd.Parameters.AddWithValue("_lastName", employee.LastName);
                cmd.Parameters.AddWithValue("_birthday", employee.Birthday);
                cmd.Parameters.AddWithValue("_email", employee.Email);
                cmd.Parameters.AddWithValue("_address", employee.Address);
                cmd.Parameters.AddWithValue("_hiringDate", employee.HiringDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_hourlyRate", employee.HourlyRate);
                cmd.Parameters.AddWithValue("_profilePicture", employee.ProfilePicture);

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

        public bool Edit(int employeeId,  Employee updatedEmployee)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_update_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_employeeCode", employeeId);
                cmd.Parameters.AddWithValue("_firstName", updatedEmployee.FirstName);
                cmd.Parameters.AddWithValue("_lastName", updatedEmployee.LastName);
                cmd.Parameters.AddWithValue("_birthday", updatedEmployee.Birthday);
                cmd.Parameters.AddWithValue("_email", updatedEmployee.Email);
                cmd.Parameters.AddWithValue("_address", updatedEmployee.Address);
                cmd.Parameters.AddWithValue("_hiringDate", updatedEmployee.HiringDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_hourlyRate", updatedEmployee.HourlyRate);
                cmd.Parameters.AddWithValue("_profilePicture", updatedEmployee.ProfilePicture);


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

        public bool Destroy(int employeeId)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_code", employeeId);

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
            ClearLocalList();

            // select * from
            // add each -> list

        }

        public void ClearLocalList()
        {
            list.Clear();
        }
    }
}
