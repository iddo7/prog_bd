using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class Admin
    {
        int id;
        string username;
        string password;

        public Admin()
        {
            id = -1;
            username = string.Empty;
            password = string.Empty;
        }

        public Admin(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Username 
        { 
            get => username;
            set
            {
                if (Utilities.ContainsSymbols(value)) throw new ArgumentException();
                username = value;
            }
        }
        public string Password 
        { 
            get => password; 
            set
            {
                if (value.Length < 8) throw new ArgumentException();
                password = value;
            }
        }
    }
}
