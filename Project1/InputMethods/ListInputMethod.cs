using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public class ListInputMethod
    {
        private List<InputMethod> _inputMethods = new List<InputMethod>();

        public void attachToForm(ref Control.ControlCollection control)
        {
            foreach (var i in this._inputMethods)
            {
                i.attachToForm(ref control);
            }
        }

        public void clear()
        {
            this._inputMethods.Clear();
        }

        public bool add(InputMethod method)
        {
            if (method != null)
            {
                this._inputMethods.Add(method);
                return true;
            }

            return false;
        }

        public void setPosition(Point beginPoint)
        {
            foreach (var i in _inputMethods)
            {
                i.setPosition(beginPoint);
                beginPoint = i.getBottomPosition();
                beginPoint.Y += 20;
            }
        }

        public bool setLabelName(List<string> names)
        {
            if (names == null || names.Count < _inputMethods.Count) return false;

            for (int i = 0; i < _inputMethods.Count; i++)
            {
                _inputMethods[i].setLabelName(names[i]);
            }

            return true;
        }

        public bool setLabelName(int index, string name)
        {
            if (index > this._inputMethods.Count || index < 0 || name == null) return false;

            this._inputMethods[index].setLabelName(name);
            return true;
        }

        public bool setWidth(int width)
        {
            if (width <= 0) return false;

            foreach (var i in this._inputMethods)
            {
                i.setWidth(width);
            }

            return true;
        }

        public bool applyData(List<object> data)
        {
            if (data.Count != this._inputMethods.Count) return false;

            for (int i = 0; i < data.Count; i++)
            {
                if (!this._inputMethods[i].applyData(data[i])) return false;
            }

            return true;
        }

        public List<object> getData()
        {
            var values = new List<object>();

            foreach (var i in this._inputMethods)
            {
                values.Add(i.getData());
            }

            return values;
        }
    }
}
