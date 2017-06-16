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
            /*BaseModelListImp<Example> example = new ArrayList<Example>();
            example.Add(new Example(1, "A", 10));
            example.Add(new Example(2, "B", 15));
            example.Add(new Example(3, "C", 20));
            example.Add(new Example(4, "D", 25));
            example.Add(new Example(5, "E", 30));
            example.Add(new Example(6, "F", 35));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm<Example>(example));*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModelForm<Example>()); 
        }
    }
}
