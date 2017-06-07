using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public class EnumSelector : InputMethod
    {
        private ComboBox _comboBox = new ComboBox();

        public override bool applyData(object data)
        {
            if (data.GetType() != this._sample.GetType())
            {
                return false;
            }

            this._comboBox.Text = data.ToString();

            return true;
        }

        public override InputMethod clone()
        {
            EnumSelector temp = new EnumSelector();
            temp._comboBox = this._comboBox;
            temp._label = this._label;
            temp._sample = this._sample;

            return temp;
        }

        public override InputMethod create(object sample)
        {
            if (!sample.GetType().IsEnum) return null;

            if (this._sample.GetType() != sample.GetType())
            {
                this._sample = sample;
                this._comboBox.Items.Clear();

                var values = Enum.GetValues(sample.GetType());

                this._comboBox.DisplayMember = "T";
                this._comboBox.ValueMember = "V";
                foreach (var v in values)
                {
                    this._comboBox.Items.Add(new { T = v.ToString(), V = v });
                }
            }

            return this.clone();
        }

        public override Point getBottomPosition()
        {
            return new Point(this._comboBox.Location.X, this._comboBox.Location.Y + this._comboBox.Height);
        }

        public override dynamic getData()
        {
            return Convert.ChangeType(this._comboBox.SelectedValue, this._sample.GetType());
        }

        protected override void _attachOtherItemToForm(Form form)
        {
            form.Controls.Add(this._comboBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            Point newLocation = this._label.Location;
            newLocation.Y = newLocation.Y + this._label.Height + DISTANCE;
        }
    }
}
