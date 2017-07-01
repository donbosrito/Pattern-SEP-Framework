using SEPFramework.Model;
using SEPFramework.Service;
using System;
using System.Windows.Forms;

namespace SEPFramework
{
    public static class DatabaseVariable
    {
        public static SqlAdapter value = null;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseVariable.value = new SqlAdapter();
            DatabaseVariable.value.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm<Example>());
        }
    }
}
