using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            foreach (var i in this._inputMethods)
            {
                i.setPosition(beginPoint);
                beginPoint = i.getBottomPosition();
            }
        }

        public bool setLabelName(List<string> names)
        {
            if (names == null || names.Count < this._inputMethods.Count) return false;

            for (int i = 0; i < this._inputMethods.Count; i++)
            {
                this._inputMethods[i].setLabelName(names[i]);
            }

            return true;
        }

        public bool setLabelName(int index, string name)
        {
            if (index > this._inputMethods.Count || index < 0 || name == null) return false;

            this._inputMethods[index].setLabelName(name);
            return true;
        }
    }
}
