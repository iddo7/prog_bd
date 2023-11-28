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

        public Employee()
        {
            this.Code = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Birthday = new DateTime();
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.HiringDate = new DateTime();
            this.HourlyRate = 0;
            this.ProfilePicture = null;
        }

        public Employee(string code, string firstName, string lastName, DateTime birthday, string email, string address, DateTime hiringDate, double hourlyRate, Uri profilePicture)
        {
            this.Code = code;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.Email = email;
            this.Address = address;
            this.HiringDate = hiringDate;
            this.HourlyRate = hourlyRate;
            this.ProfilePicture = profilePicture;
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
                if (Utilities.ContainsNumbers(value) || Utilities.ContainsSymbols(value)) throw new ArgumentException("Invalid first name");

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (Utilities.ContainsNumbers(value) || Utilities.ContainsSymbols(value)) throw new ArgumentException("Invalid last name");

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

        public string Address { get => address; set => address = value; }

        public DateTime HiringDate 
        {
            get => hiringDate;
            set
            {
                if (value > DateTime.Today) throw new ArgumentException("Hiring Date cannot be in future");

                hiringDate = value;
            }
        }

        public double HourlyRate 
        { 
            get => hourlyRate; 
            set
            {
                if (hourlyRate < 0) throw new ArgumentOutOfRangeException(nameof(hourlyRate));

                hourlyRate = value;
            }
        }
        public Uri ProfilePicture { get => profilePicture; set => profilePicture = value; }

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
                   $"Profile Picture URI: {ProfilePicture?.ToString() ?? "N/A"}\n";
        }

    }
}
