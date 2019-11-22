using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aariaz_Workshop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Products Start;
        public static Dashboard Form;

        [STAThread]
        private static void Main()
        {
            Start = new Products();
            Form = new Dashboard();
            Application.Run(Start);
        }
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Dashboard());
        //}
    }
}
