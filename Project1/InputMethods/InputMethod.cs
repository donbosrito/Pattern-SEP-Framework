using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public abstract class InputMethod
    {
        protected const int DISTANCE = 0;

        protected Label _label = new Label();
        protected Type _sampleType = null;

        protected abstract void _attachOtherItemToForm(ref Control.ControlCollection control);
        protected abstract void _setOtherItemPosition(Point p);

        public abstract Point getBottomPosition();
        public abstract bool applyData(object data);
        public abstract dynamic getData();
        public abstract InputMethod create(Type type);
        public abstract void setWidth(int width);

        public InputMethod clone()
        {
            return (InputMethod)MemberwiseClone();
        }

        public void attachToForm(ref Control.ControlCollection control)
        {
            control.Add(_label);
            _attachOtherItemToForm(ref control);
        }

        public void setLabelName(string name)
        {
            _label.Text = name;
            _label.Update();
        }

        public void setPosition(Point p)
        {
            _label.Location = p;
            Point bottom = new Point(p.X, p.Y + _label.Height);
            _setOtherItemPosition(bottom);
        }
    }
}
