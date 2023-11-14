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

        public string Code 
        { 
            get => code; 
            set 
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                code = value;
            } 
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Birthday 
        { 
            get => birthday;
            set 
            {
                int age = Utilities.CurrentAge(birthday);
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
    }
}
