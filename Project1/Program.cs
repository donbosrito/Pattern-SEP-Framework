using SEPFramework.MemberShip;
using SEPFramework.Model;
using SEPFramework.Service;
using System;
using System.Windows.Forms;
using SEPFramework.SEPControl;

namespace SEPFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBAdapter mainAdapter = new SqlAdapter(Properties.Settings.Default.DefaultConnection);
            DBAdapter accountAdapter = new SqlAdapter(Properties.Settings.Default.AccountConnection);
            IControl<Example> c = new MainFormAndMembership<Example>(mainAdapter, accountAdapter);
            c.start();
        }
    }
}
