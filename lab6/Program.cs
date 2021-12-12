using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseContext;
using Core;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var connectionString = "User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=University";
            var context = new UniversityContext(connectionString);
            IFacade facade = new Facade(context);
            Application.Run(new Presentation(facade));
        }
    }
}
