using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class Project
    {
        string code;
        string title;
        DateTime startDate;
        string description;
        int budget;
        int numberOfEmployees;
        int totalSalaries;
        Client client;
        string status;

        public Project()
        {
            this.Code = string.Empty;
            this.Title = string.Empty;
            this.StartDate = startDate;
            this.Description = string.Empty;
            this.Budget = budget;
            this.NumberOfEmployees = numberOfEmployees;
            this.TotalSalaries = totalSalaries;
            this.Client = client;
            this.Status = "En cours";
        }

        public Project(string code, string title, DateTime startDate, string description, int budget, int numberOfEmployees, int totalSalaries, Client client, string status)
        {
            this.Code = code;
            this.Title = title;
            this.StartDate = startDate;
            this.Description = description;
            this.Budget = budget;
            this.NumberOfEmployees = numberOfEmployees;
            this.TotalSalaries = totalSalaries;
            this.Client = client;
            this.Status = status;
        }

        public string Code { get => code; set => code = value; }
        public string Title { get => title; set => title = value; }
        public DateTime StartDate 
        { 
            get => startDate; 
            set
            {
                if (value < DateTime.Today) throw new ArgumentException("Invalid Start Date");
            }
        }
        public string Description { get => description; set => description = value; }
        public int Budget 
        { 
            get => budget; 
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Invalid budget");

                budget = value;
            }
        }
        public int NumberOfEmployees 
        { 
            get => numberOfEmployees; 
            set
            {
                if (value <= 0 || value > 5) throw new ArgumentOutOfRangeException("Invalid number of employees");

                numberOfEmployees = value;
            }
        }
        public int TotalSalaries 
        { 
            get => totalSalaries; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Invalid total salaries");

                totalSalaries = value;
            }
        }
        public string Status 
        { 
            get => status; 
            set
            {
                if (value != "En cours" || value != "Terminé") throw new ArgumentException("Invalid status");

                status = value;
            }
        }
        internal Client Client { get => client; set => client = value; }
    }
}
