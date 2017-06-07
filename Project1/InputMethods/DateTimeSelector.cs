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

        protected override void _attachOtherItemToForm(Form form)
        {
            form.Controls.Add(this._dateTimePicker);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._dateTimePicker.Location = p;
        }
    }
}
