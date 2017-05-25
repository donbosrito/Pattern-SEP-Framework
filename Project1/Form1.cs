using Project1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1<T> : Form where T : BaseModel 
    {
        BaseModelListImp<T> data;
        public Form1()
        {
            base.InitializeComponent();
        }

        public Form1(BaseModelListImp<T> data)
        {
            base.InitializeComponent();
            this.data = data;
        }
    }
}
