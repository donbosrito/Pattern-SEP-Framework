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

            if (this._sampleType != type)
            {
                this._sampleType = type;
                this._comboBox.Items.Clear();

                var values = Enum.GetValues(type);

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
            return Convert.ChangeType(this._comboBox.SelectedValue, this._sampleType);
        }

        protected override void _attachOtherItemToForm(Form form)
        {
            form.Controls.Add(this._comboBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._comboBox.Location = p;
        }
    }
}
