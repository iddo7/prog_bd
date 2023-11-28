using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class ClientSingleton
    {
        MySqlConnection conn;
        ObservableCollection<Client> list;
        static ClientSingleton instance = null;

        public ClientSingleton()
        {
            list = new ObservableCollection<Client>();
            conn = new MySqlConnection(BdConnexionInfo.ConnectionString());
        }

        public static ClientSingleton Instance()
        {
            if (instance == null) instance = new ClientSingleton();
            return instance;
        }

        public ObservableCollection<Client> List()
        {
            UpdateLocalList();
            return list;
        }

        public Client Client(int index)
        {
            return (Client)list[index];
        }

        public bool Create(Client client)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_insert_client");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_fullname", client.FullName);
                cmd.Parameters.AddWithValue("_address", client.Address);
                cmd.Parameters.AddWithValue("_phoneNumber", client.PhoneNumber);
                cmd.Parameters.AddWithValue("_email", client.Email);

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

        public bool Edit(int clientId, Client updatedClient)
        {
            bool success = true;

            try 
            {
                MySqlCommand cmd = new MySqlCommand("p_update_client");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_id", clientId);
                cmd.Parameters.AddWithValue("_fullname", updatedClient.FullName);
                cmd.Parameters.AddWithValue("_address", updatedClient.Address);
                cmd.Parameters.AddWithValue("_phoneNumber", updatedClient.PhoneNumber);
                cmd.Parameters.AddWithValue("_email", updatedClient.Email);

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

        public bool Destroy(int clientId)
        {
            bool success = true;

            try
            {
                MySqlCommand cmd = new MySqlCommand("p_delete_client");
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_id", clientId);

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
