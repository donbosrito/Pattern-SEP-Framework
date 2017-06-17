﻿using SEPFramework.Model;
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
            BaseModelListImp<Example> example = new ArrayList<Example>();
            example.Add(new Example("A", 10, Gender.Female));
            example.Add(new Example("B", 15, Gender.Male));
            example.Add(new Example("C", 20, Gender.Male));
            example.Add(new Example("D", 25, Gender.Male));
            example.Add(new Example("E", 30, Gender.Female));
            example.Add(new Example("F", 35, Gender.Female));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm<Example>(example));
        }
    }
}
