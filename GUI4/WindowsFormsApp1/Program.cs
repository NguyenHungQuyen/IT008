using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  connect= System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            connect = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyLopHoc;Integrated Security=True";
            Application.Run(new Form1());
        }
        public static string connect;
    }
}
