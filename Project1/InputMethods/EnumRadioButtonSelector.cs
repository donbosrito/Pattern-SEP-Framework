using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public class EnumRadioButtonSelector : InputMethod
    {
        private GroupBox _groupRadioButton = new GroupBox();
        private RadioButton[] _radioButtons = new RadioButton[2];

        public EnumRadioButtonSelector()
        {
            for (int i = 0; i < this._radioButtons.Length; i++)
            {
                this._radioButtons[i] = new RadioButton();
            }

            foreach (var r in this._radioButtons)
            {
                this._groupRadioButton.Controls.Add(r);
            }
        }

        public override bool applyData(object data)
        {
            if (data.GetType() != this._sampleType) return false;

            foreach (var r in this._radioButtons)
            {
                if (data.ToString() == r.Text)
                {
                    r.Checked = true;
                    break;
                }
            }

            return true;
        }

        public override InputMethod create(Type type)
        {
            if (!type.IsEnum) return null;

            var values = Enum.GetValues(type);

            if (values.Length > 2) return null;

            if (this._sampleType != type)
            {
                this._sampleType = type;
                int i = 0;
                foreach (var v in values)
                {
                    this._radioButtons[i].Text = v.ToString();
                    i++;
                }

                if (i == 1)
                {
                    this._radioButtons[i].Visible = false;
                }
                else
                {
                    this._radioButtons[1].Visible = true;
                }

                this._radioButtons[0].Checked = true;
            }

            return this.clone();
        }

        public override Point getBottomPosition()
        {
            return new Point(this._groupRadioButton.Location.X, this._groupRadioButton.Location.Y + this._groupRadioButton.Height);
        }

        public override dynamic getData()
        {
            var text = this._radioButtons[0].Text;
            if (this._radioButtons[1].Checked == true)
            {
                text = this._radioButtons[1].Text;
            }

            return Enum.Parse(this._sampleType, text);
        }

        public override void setWidth(int width)
        {
            this._groupRadioButton.Width = width;
            this._groupRadioButton.Height = this._radioButtons[0].Height;
            this._radioButtons[0].Location = this._groupRadioButton.Location;
            Point t_pos = this._groupRadioButton.Location;
            t_pos.X = t_pos.X + 5 + this._radioButtons[0].Width;
            this._radioButtons[1].Location = t_pos;
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(this._groupRadioButton);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._groupRadioButton.Location = p;
        }
    }
}
