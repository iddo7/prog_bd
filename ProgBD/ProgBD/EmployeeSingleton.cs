
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

            // Create -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Edit(int employeeId,  Employee updatedEmployee)
        {
            bool success = true;

            // Edit -> BD

            if (success) UpdateLocalList();
            return success;
        }

        public bool Destroy(int employeeId)
        {
            bool success = true;

            // Detroy -> BD

            if (success) UpdateLocalList();
            return success;
        }


        public void UpdateLocalList()
        {
            list.Clear();

            // select * from employees
            // add each -> list

        }

        public void ClearLocalList()
        {
            list.Clear();
        }
    }
}
