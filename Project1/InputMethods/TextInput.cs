using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public class TextInput : InputMethod
    {
        private TextBox _textBox = new TextBox();

        public TextInput()
        {
            this._sampleType = typeof(string);
        }

        public override bool applyData(object data)
        {
            if (data.GetType() == this._sampleType)
            {
                this._textBox.Text = (string)data;
                this._textBox.Update();

                return true;
            }

            return false;
        }

        public override InputMethod create(Type type)
        {
            if (type == this._sampleType)
            {
                return clone();
            }

            return null;
        }

        public override Point getBottomPosition()
        {
            return new Point(this._textBox.Location.X, this._textBox.Location.Y + this._textBox.Height);
        }

        public override dynamic getData()
        {
            return this._textBox.Text;
        }

        public override void setWidth(int width)
        {
            if (width <= 0) return;

            this._textBox.Width = width;
            this._textBox.Update();
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(this._textBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._textBox.Location = p;
        }
    }
}
