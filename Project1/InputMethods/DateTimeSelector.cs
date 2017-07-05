using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public class DateTimeSelector : InputMethod
    {
        private DateTimePicker _dateTimePicker = new DateTimePicker();
        public DateTimeSelector()
        {
            this._sampleType = typeof(DateTime);
            this._dateTimePicker.Format = DateTimePickerFormat.Custom;
            this._dateTimePicker.CustomFormat = "dd / MM / yyyy";
            
        }

        public override bool applyData(object data)
        {
            if (data.GetType() == this._sampleType)
            {
                this._dateTimePicker.Value = (DateTime)data;
                this._dateTimePicker.Update();
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
            return new Point(this._dateTimePicker.Location.X, this._dateTimePicker.Location.Y + this._dateTimePicker.Height);
        }

        public override dynamic getData()
        {
            return this._dateTimePicker.Value;
        }

        public override bool isEnabled()
        {
            return _dateTimePicker.Enabled;
        }

        public override void setEnable(bool isEnable)
        {
            _dateTimePicker.Enabled = isEnable;
        }

        public override void setWidth(int width)
        {
            if (width <= 0) return;

            this._dateTimePicker.Width = width;
            this._dateTimePicker.Update();
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(this._dateTimePicker);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._dateTimePicker.Location = p;
        }
    }
}
