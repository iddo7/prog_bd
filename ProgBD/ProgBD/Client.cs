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

            this.fullName = string.Empty;
            this.address = string.Empty;
            this.phoneNumber = string.Empty;
            this.email = string.Empty;
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
                if (
                    Utilities.ContainsNumbers(value) || 
                    Utilities.ContainsSymbols(value) || 
                    value == string.Empty
                    )
                    throw new ArgumentException("Invalid full name");

                fullName = value;
            }
        }

        public string Address
        {
            get => address;
            set
            {
                if (Utilities.ContainsSymbols(value) || 
                    value == string.Empty)
                {
                    throw new ArgumentException("Address cannot be empty");
                }


                address = value;
            }
        }
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
    }
}
