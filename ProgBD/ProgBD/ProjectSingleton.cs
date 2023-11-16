using MySql.Data.MySqlClient;
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
            conn = new MySqlConnection("Server=cours.cegep3r.info;Database=2236478-isaac-negreiros;Uid=2236478;Pwd=2236478;");
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

            // Create -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Edit(int projectId, Project updatedProject)
        {
            bool success = true;

            // Edit -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Destroy(int projectId)
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
