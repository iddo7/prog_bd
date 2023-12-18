using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class AuthSingleton
    {
        MySqlConnection conn;
        ObservableCollection<Admin> list;
        bool isConnected;
        Admin connectedAdmin;
        static AuthSingleton instance = null;

        public AuthSingleton()
        {
            list = new ObservableCollection<Admin>();
            conn = new MySqlConnection(BdConnexionInfo.ConnectionString());
        }

        public static AuthSingleton Instance()
        {
            if (instance == null) instance = new AuthSingleton();
            return instance;
        }

        public ObservableCollection<Admin> List()
        {
            UpdateLocalList();
            return list;
        }

        public Admin Admin(int index)
        {
            return (Admin)list[index];
        }

        public Admin ConnectedAdmin()
        {
            return connectedAdmin;
        }

        public bool Create(Admin admin)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_insert_admin");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_username", admin.Username);
                cmd.Parameters.AddWithValue("_password", Utilities.HashSHA256(admin.Password));

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery();
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

        public bool Edit(int adminId, Admin updatedAdmin)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_update_employee_project");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_adminId", adminId);
                cmd.Parameters.AddWithValue("_newUsername", updatedAdmin.Username);
                cmd.Parameters.AddWithValue("_newPassword", Utilities.HashSHA256(updatedAdmin.Password));


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

        public bool Destroy(int adminId)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_admin");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_adminId", adminId);

                conn.Open();
                cmd.Prepare();
                int i = cmd.ExecuteNonQuery();
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
                MySqlCommand cmd = new MySqlCommand("p_select_admins");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string username = (string)reader["username"];
                    string password = (string)reader["password"];

                    Admin task = new Admin
                    (
                        id,
                        username,
                        password
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

        public bool Login(string username, string password)
        {
            UpdateLocalList();
            bool success = false;
            foreach (Admin admin in list)
            {
                if (username == admin.Username && password == admin.Password)
                {
                    success = true;
                    break;
                }
            }

            SetConnection(success);
            return success;
        }

        public bool HasAdmins()
        {
            return list.Count > 0;
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        public void SetConnection(bool connection, Admin admin = null)
        {
            isConnected = connection;
            connectedAdmin = admin;
        }
    }
}