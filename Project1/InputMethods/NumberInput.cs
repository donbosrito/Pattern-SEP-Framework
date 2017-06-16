using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.InputMethods
{
    public static class GetMaxValue
    {
        public static dynamic getMax(this Type value)
        {
            dynamic v = Convert.ChangeType(value.GetField("MaxValue").GetValue(null), value);

            return v;
        }
    }

    public static class GetMinValue
    {
        public static dynamic getMin(this Type value)
        {
            dynamic v = Convert.ChangeType(value.GetField("MinValue").GetValue(null), value);

            return v;
        }
    }

    public static class IsInteger
    {
        private static HashSet<Type> _numberType = new HashSet<Type> {
            typeof(sbyte), typeof(byte), typeof(short), typeof(ushort),
            typeof(int), typeof(uint), typeof(long), typeof(ulong)
        };

        public static bool IsIntegerType(this Type type)
        {
            return _numberType.Contains(type);
        }
    }

    public static class IsReal
    {
        private static HashSet<Type> _numberType = new HashSet<Type> {
            typeof(float), typeof(double), typeof(decimal)
        };

        public static bool IsRealType(this Type type)
        {
            return _numberType.Contains(type);
        }
    }

    public class NumberInput : InputMethod
    {
        private const decimal INTEGER_INCREMENT = 1;
        private const decimal FLOATING_POINT_INCREMENT = (decimal)0.1;

        private NumericUpDown _numberBox = new NumericUpDown();

        public override bool applyData(object data)
        {
            if (data.GetType() == this._sampleType)
            {
                this._numberBox.Value = (decimal)data;
                this._numberBox.Update();
                return true;
            }

            return false;
        }

        public override InputMethod create(Type type)
        {
            if (!type.IsIntegerType() && !type.IsRealType())
            {
                return null;
            }

            if (type != this._sampleType)
            {
                if (type.IsRealType())
                {
                    this._numberBox.DecimalPlaces = 5;
                    this._numberBox.Increment = FLOATING_POINT_INCREMENT;
                    this._numberBox.Maximum = typeof(decimal).getMax();
                    this._numberBox.Minimum = typeof(decimal).getMin();
                }

                if (type.IsIntegerType())
                {
                    this._numberBox.DecimalPlaces = 0;
                    this._numberBox.Increment = INTEGER_INCREMENT;
                    this._numberBox.Maximum = (decimal)type.getMax();
                    this._numberBox.Minimum = (decimal)type.getMin();
                }

                this._sampleType = type;
            }

            return this.clone();
        }

        public override Point getBottomPosition()
        {
            return new Point(this._numberBox.Location.X, this._numberBox.Location.Y + this._numberBox.Height);
        }

        public override dynamic getData()
        {
            return Convert.ChangeType(this._numberBox.Value, this._sampleType);
        }

        public override void setWidth(int width)
        {
            if (width <= 0) return;

            this._numberBox.Width = width;
            this._numberBox.Update();
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(this._numberBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            this._numberBox.Location = p;
        }
    }
}
