﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public abstract class InputMethod
    {
        protected const int DISTANCE = 10;

        protected System.Windows.Forms.Label _label = new Label();
        protected Type _sampleType = null;

        protected abstract void _attachOtherItemToForm(ref Control.ControlCollection control);
        protected abstract void _setOtherItemPosition(Point p);

        public abstract Point getBottomPosition();
        public abstract bool applyData(object data);
        public abstract dynamic getData();
        public abstract InputMethod create(Type type);

        public InputMethod clone()
        {
            return (InputMethod)this.MemberwiseClone();
        }

        public void attachToForm(ref Control.ControlCollection control)
        {
            control.Add(this._label);
            this._attachOtherItemToForm(ref control);
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
            this._setOtherItemPosition(bottom);
        }
    }
}