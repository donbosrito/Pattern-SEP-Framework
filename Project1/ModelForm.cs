using SEPFramework.Model;
using SEPFramework.InputMethods;
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
    public partial class ModelForm<T> : Form where T : BaseModel, new()
    {
        //Add Form
        public ModelForm()
        {
            InitializeComponent();
            generate();
            setPosition();
        }

        //Edit Form
        public ModelForm(int ID)
        {
            InitializeComponent();
            generate();
            setPosition();
        }

        private void generate()
        {
            T sample = new T();
            this.controls = InputMethodFactory<T>.getInstance().create(sample);
            var c = this.panel_Main.Controls;
            var names = sample.getNames();
            this.controls.setLabelName(names);
            this.controls.attachToForm(ref c);
            this.controls.setWidth(this.panel_Main.Width);
        }

        private void setPosition()
        {
            Point p = this.panel_Main.Location;
            this.controls.setPosition(p);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
