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
            DBAdapter mainAdapter = new SqlAdapter("Data Source = PC1\\SQLEXPRESS; Initial Catalog = ExampleDatabase; Integrated Security = False;Trusted_Connection=True");
            DBAdapter accountAdapter = new SqlAdapter("Data Source=PC1\\SQLEXPRESS;Initial Catalog=Account;Integrated Security=False;Trusted_Connection=True");
            IControl<Example> c = new MainFormAndMembership<Example>(mainAdapter, accountAdapter);
            c.start();
        }
    }
}
