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
    public class EnumComboBoxSelector : InputMethod
    {
        private ComboBox _comboBox = new ComboBox();

        public override bool applyData(object data)
        {
            if (data.GetType() != this._sampleType)
            {
                return false;
            }

            this._comboBox.SelectedText = data.ToString();

            return true;
        }

        public override InputMethod create(Type type)
        {
            if (!type.IsEnum) return null;

            var values = Enum.GetValues(type);

            if (values.Length < 3) return null;

            if (this._sampleType != type)
            {
                this._sampleType = type;
                this._comboBox.Items.Clear();


                this._comboBox.DisplayMember = "T";
                this._comboBox.ValueMember = "V";
                foreach (var v in values)
                {
                    this._comboBox.Items.Add(new { T = v.ToString(), V = v });
                }
                this._comboBox.SelectedItem = this._comboBox.Items[0];
            }

            return this.clone();
        }

        public override Point getBottomPosition()
        {
            return new Point(this._comboBox.Location.X, this._comboBox.Location.Y + this._comboBox.Height);
        }

        public override dynamic getData()
        {
            return Convert.ChangeType(this._comboBox.SelectedValue, this._sampleType);
        }

        public override bool isEnabled()
        {
            return _comboBox.Enabled;
        }

        public override void setEnable(bool isEnable)
        {
            _comboBox.Enabled = isEnable;
        }

        public override void setWidth(int width)
        {
            if (width <= 0) return;

            this._comboBox.Width = width;
            this._comboBox.Update();
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(this._comboBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._comboBox.Location = p;
        }
    }
}
