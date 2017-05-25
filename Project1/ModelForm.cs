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

namespace SEPFramework
{
    public partial class ModelForm<T> : Form where T : BaseModel
    {
        public ModelForm()
        {
            InitializeComponent();
        }
    }
}
