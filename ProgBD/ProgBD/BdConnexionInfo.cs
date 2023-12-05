using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal static class BdConnexionInfo
    {
        private static string server = "cours.cegep3r.info";
        private static string database = "a2023_420325ri_fabeq18";
        private static string username = "2236478";
        private static string password = "2236478";

        public static string Server { get => server; }
        public static string Database { get => database; }
        public static string Username { get => username; }
        public static string Password { get => password; }

        public static string ConnectionString()
        {
            return $"Server={server};Database={database};Uid={username};Pwd={password};";
        }
    }
}
