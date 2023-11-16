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
            conn = new MySqlConnection("Server=cours.cegep3r.info;Database=2236478-isaac-negreiros;Uid=2236478;Pwd=2236478;");
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

        public bool Create(Client Client)
        {
            bool success = true;

            // Create -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Edit(int clientId, Client updatedClient)
        {
            bool success = true;

            // Edit -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Destroy(int clientId)
        {
            bool success = true;

            // Detroy -> BD

            if (success) UpdateLocalList();
            return success;
        }


        public void UpdateLocalList()
        {
            list.Clear();

            // select * from
            // add each -> list

        }

        public void ClearLocalList()
        {
            list.Clear();
        }
    }
}
