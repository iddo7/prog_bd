using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class User
    {
        string username;
        string password;

        public User()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
