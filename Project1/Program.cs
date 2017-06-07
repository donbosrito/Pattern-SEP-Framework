using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            BaseModelListImp<Example> lstExample = new ArrayList<Example>();
            lstExample.add(new Example("A", 26));
            lstExample.add(new Example("B", 1));
            lstExample.add(new Example("C", 100));
            lstExample.add(new Example("D", 500));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm<Example>(lstExample));
        }
    }
}
