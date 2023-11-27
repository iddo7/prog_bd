
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
            conn = new MySqlConnection("Server=cours.cegep3r.info;Database=2236478-isaac-negreiros;Uid=2236478;Pwd=2236478;");
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
                cmd.Parameters.AddWithValue("_firstName", employee.firstName);
                cmd.Parameters.AddWithValue("_lastName", employee.lastName);
                cmd.Parameters.AddWithValue("_birthday", employee.birthday);
                cmd.Parameters.AddWithValue("_email", employee.email);
                cmd.Parameters.AddWithValue("_address", employee.address);
                cmd.Parameters.AddWithValue("_hiringDate", employee.hiringDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_hourlyRate", employee.hourlyRate);
                cmd.Parameters.AddWithValue("_profilePicture", employee.profilePicture);

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
                cmd.Parameters.AddWithValue("_firstName", updatedEmployee.firstName);
                cmd.Parameters.AddWithValue("_lastName", updatedEmployee.lastName);
                cmd.Parameters.AddWithValue("_birthday", updatedEmployee.birthday);
                cmd.Parameters.AddWithValue("_email", updatedEmployee.email);
                cmd.Parameters.AddWithValue("_address", updatedEmployee.address);
                cmd.Parameters.AddWithValue("_hiringDate", updatedEmployee.hiringDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_hourlyRate", updatedEmployee.hourlyRate);
                cmd.Parameters.AddWithValue("_profilePicture", updatedEmployee.profilePicture);


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
