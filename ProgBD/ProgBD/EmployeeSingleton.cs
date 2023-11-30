
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
                cmd.Parameters.AddWithValue("_status", employee.Status);

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

        public bool Edit(string employeeCode,  Employee updatedEmployee)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_update_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_employeeCode", employeeCode);
                cmd.Parameters.AddWithValue("_firstName", updatedEmployee.FirstName);
                cmd.Parameters.AddWithValue("_lastName", updatedEmployee.LastName);
                cmd.Parameters.AddWithValue("_birthday", updatedEmployee.Birthday);
                cmd.Parameters.AddWithValue("_email", updatedEmployee.Email);
                cmd.Parameters.AddWithValue("_address", updatedEmployee.Address);
                cmd.Parameters.AddWithValue("_hiringDate", updatedEmployee.HiringDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("_hourlyRate", updatedEmployee.HourlyRate);
                cmd.Parameters.AddWithValue("_profilePicture", updatedEmployee.ProfilePicture);
                cmd.Parameters.AddWithValue("_status", updatedEmployee.Status);


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

        public bool Destroy(string employeeCode)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_employee");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_code", employeeCode);

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

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_select_employees");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    string code = (string)reader["code"];
                    string firstName = (string)reader["firstName"];
                    string lastName = (string)reader["lastName"];
                    DateTime birthday = (DateTime)reader["birthday"];
                    string email = (string)reader["email"];
                    string address = (string)reader["address"];
                    DateTime hiringDate = (DateTime)reader["hiringDate"];
                    double hourlyRate = (double)reader["hourlyRate"];
                    // You may need to adjust how you retrieve the Uri for the profile picture
                    Uri profilePicture = new Uri((string)reader["profilePicture"]);
                    string status = (string)reader["status"];

                    Employee employee = new Employee
                    (
                        code,
                        firstName,
                        lastName,
                        birthday,
                        email,
                        address,
                        hiringDate,
                        hourlyRate,
                        profilePicture,
                        status
                    );

                    list.Add(employee);
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
