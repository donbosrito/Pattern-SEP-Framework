using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Project1.InputMethods
{
    public abstract class InputMethod
    {
        protected System.Windows.Forms.Label _label = new Label();
        protected object _sample = null;

        protected abstract void _attachOtherItemToForm(Form form);
        protected abstract void _setOtherItemPosition(Point p);

        public abstract Point getBottomPosition();
        public abstract bool applyData(object data);
        public abstract dynamic getData();
        public abstract InputMethod create(object sample);

        public void attachToForm(Form form)
        {
            form.Controls.Add(this._label);
            this._attachOtherItemToForm(form);
        }

        public void setLabelName(string name)
        {
            this._label.Text = name;
            this._label.Update();
        }

        public void setPosition(Point p)
        {
            this._label.Location = p;
            Point bottom = new Point(p.X, p.Y + this._label.Height);
        }
    }
}
