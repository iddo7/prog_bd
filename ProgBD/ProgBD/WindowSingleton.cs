using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class WindowSingleton
    {
        static WindowSingleton instance = null;
        NavigationView navigationView;
        MainWindow mainWindow;

        public static WindowSingleton Instance()
        {
            if (instance == null) instance = new WindowSingleton();
            return instance;
        }

        public NavigationView Nav
        {
            get { return navigationView; }
            set { navigationView = value; }
        }

        public MainWindow MainWindow
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }
    }
}
