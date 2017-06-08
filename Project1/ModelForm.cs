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
        public ModelForm()
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
            this.controls.attachToForm(ref c);
        }

        private void setPosition()
        {
            Point p = this.panel_Main.Location;
            this.controls.setPosition(p);
        }
    }
}
