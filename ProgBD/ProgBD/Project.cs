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
        double budget;
        int numberOfEmployees;
        double totalSalaries;
        Client client;
        string status;
        
        

        public Project()
        {
            this.code = string.Empty;
            this.title = string.Empty;
            this.startDate = new DateTime();
            this.description = string.Empty;
            this.budget = 0;
            this.numberOfEmployees = 0;
            this.totalSalaries = 0;
            this.client = new Client();
            this.status = "En cours";
        }

        public Project(string code, string title, DateTime startDate, string description, double budget, int numberOfEmployees, double totalSalaries, Client client, string status)
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
        public string Title 
        { 
            get => title; 
            set
            {
                if (value == string.Empty) throw new ArgumentException("Invalid title");

                title = value;
            }
        }
        public DateTime StartDate 
        { 
            get => startDate; 
            set
            {
                if (value < DateTime.Today) throw new ArgumentException("Invalid Start Date");

                startDate = value;
            }
        }
        public string Description 
        { 
            get => description; 
            set
            {
                if (value == string.Empty) throw new ArgumentException("Invalid description");

                description = value;
            }
        }
        public double Budget 
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
        public double TotalSalaries 
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
                if (value != "En cours" && value != "Terminé") throw new ArgumentException("Invalid status");

                status = value;
            }
        }
        internal Client Client 
        { 
            
            get => client; 
            set 
            {
                if (value == null) throw new ArgumentException("Invalid client");

                client = value;
            } 
        }

        public override string ToString()
        {
            return $"Project Code: {Code}\n" +
                   $"Title: {Title}\n" +
                   $"Start Date: {StartDate.ToShortDateString()}\n" +
                   $"Description: {Description}\n" +
                   $"Budget: {Budget}\n" +
                   $"Number of Employees: {NumberOfEmployees}\n" +
                   $"Total Salaries: {TotalSalaries}\n" +
                   $"Client: {Client.ToString()}\n" +
                   $"Status: {Status}\n";
        }

        public string ToCSV()
        {
            return $"{Code};{Title};{StartDate};{Description};{Budget};{NumberOfEmployees};{TotalSalaries};{Client.Id};{Status}";
        }

    }
}
