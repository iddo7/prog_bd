using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace ProgBD
{
    internal class Client
    {
        static int idCounter = 100;
        int id;
        string fullName;
        string address;
        string phoneNumber;
        string email;

        public Client()
        {
            this.id = idCounter;
            idCounter++;

            this.FullName = string.Empty;
            this.Address = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
        }

        public Client(int id, string fullName, string address, string phoneNumber, string email)
        {
            this.id = idCounter;
            idCounter++;

            this.FullName = fullName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public static int IdCounter { get => idCounter; }
        public int Id { get => id; }

        public string FullName 
        { 
            get => fullName; 
            set
            {
                if (Utilities.ContainsNumbers(value) || Utilities.ContainsSymbols(value)) throw new ArgumentException("Invalid full name");

                fullName = value;
            }
        }

        public string Address { get => address; set => address = value; }
        public string PhoneNumber 
        { 
            get => phoneNumber; 
            set
            {
                if (!Utilities.IsValidPhoneNumber(value)) throw new ArgumentException("Invalid phone number");

                phoneNumber = value;
            }
        }
        public string Email 
        { 
            get => email; 
            set
            {
                if (!Utilities.IsValidEmail(value)) throw new ArgumentException("Invalid email address");

                email = value;
            }
        }

        public override string ToString()
        {
            return $"Client ID: {Id}\n" +
                   $"Full Name: {FullName}\n" +
                   $"Address: {Address}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Email: {Email}\n";
        }

        public bool Equals(Client other)
        {
            return this.Id == other.Id;
        }

        public bool Equals(int otherId)
        {
            return this.Id == otherId;
        }

    }
}
