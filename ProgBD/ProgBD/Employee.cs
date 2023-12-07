using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class Employee
    {
        string code;
        string firstName;
        string lastName;
        DateTime birthday;
        string email;
        string address;
        DateTime hiringDate;
        double hourlyRate;
        Uri profilePicture;
        string status;

        public Employee()
        {
            this.code = string.Empty;
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.birthday = new DateTime();
            this.email = string.Empty;
            this.address = string.Empty;
            this.hiringDate = new DateTime();
            this.hourlyRate = 0;
            this.profilePicture = null;
            this.status = "Journalier";
        }

        public Employee(string code, string firstName, string lastName, DateTime birthday, string email, string address, DateTime hiringDate, double hourlyRate, Uri profilePicture, string status)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.Email = email;
            this.Address = address;
            this.HiringDate = hiringDate;
            this.HourlyRate = hourlyRate;
            this.ProfilePicture = profilePicture;
            this.Status = status;
        }

        public string Code 
        { 
            get => code; 
            set 
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                code = value;
            } 
        }

        public string FirstName 
        { 
            get => firstName; 
            set
            {
                if (
                    Utilities.ContainsNumbers(value) || 
                    Utilities.ContainsSymbols(value) ||
                    value == string.Empty
                ) throw new ArgumentException("Invalid first name");

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (
                    Utilities.ContainsNumbers(value) || 
                    Utilities.ContainsSymbols(value) ||
                    value == string.Empty
                ) throw new ArgumentException("Invalid last name");

                lastName = value;
            }
        }

        public DateTime Birthday 
        { 
            get => birthday;
            set 
            {
                int age = Utilities.CurrentAge(value);
                if (age < 18 || age > 65) throw new ArgumentException("Invalid birthday");

                birthday = value;
            }
        }

        public string Email
        { 
            get => email;
            set
            {
                if (!Utilities.IsValidEmail(value)) throw new ArgumentException("Invalid email address.");

                email = value;
            }
        }

        public string Address 
        { 
            get => address;
            set
            {
                if (value == string.Empty) throw new ArgumentException("Invalid address");
                address = value;
            } 
        }

        public DateTime HiringDate 
        {
            get => hiringDate;
            set
            {
                if (value > DateTime.Today || value < new DateTime(1940, 1, 1)) throw new ArgumentException("Hiring Date cannot be in future");


                hiringDate = value;
            }
        }

        public double HourlyRate 
        { 
            get => hourlyRate; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(hourlyRate));

                hourlyRate = value;
            }
        }
        public Uri ProfilePicture { get => profilePicture; set => profilePicture = value; }
        public string Status 
        { 
            get => status; 
            set
            {
                if (value != "Journalier" && value != "Permanent") throw new ArgumentException("Invalid status");
                status = value;
            }
        }

        public override string ToString()
        {
            return $"Employee Code: {Code}\n" +
                   $"First Name: {FirstName}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Birthday: {Birthday.ToShortDateString()}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n" +
                   $"Hiring Date: {HiringDate.ToShortDateString()}\n" +
                   $"Hourly Rate: {HourlyRate}\n" +
                   $"Profile Picture URI: {ProfilePicture?.ToString() ?? "N/A"}\n" +
                   $"Status: {status}\n";
        }

    }
}
