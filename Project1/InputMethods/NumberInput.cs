using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (data.GetType() == _sampleType)
            {
                _numberBox.Value = decimal.Parse(data.ToString());
                _numberBox.Update();
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

            if (type != _sampleType)
            {
                if (type.IsRealType())
                {
                    _numberBox.DecimalPlaces = 5;
                    _numberBox.Increment = FLOATING_POINT_INCREMENT;
                    _numberBox.Maximum = typeof(decimal).getMax();
                    _numberBox.Minimum = typeof(decimal).getMin();
                }

                if (type.IsIntegerType())
                {
                    _numberBox.DecimalPlaces = 0;
                    _numberBox.Increment = INTEGER_INCREMENT;
                    _numberBox.Maximum = (decimal)type.getMax();
                    _numberBox.Minimum = (decimal)type.getMin();
                }

                _sampleType = type;
            }

            return clone();
        }

        public override Point getBottomPosition()
        {
            return new Point(_numberBox.Location.X, _numberBox.Location.Y + _numberBox.Height);
        }

        public override dynamic getData()
        {
            return Convert.ChangeType(_numberBox.Value, _sampleType);
        }

        public override void setWidth(int width)
        {
            if (width <= 0) return;

            _numberBox.Width = width;
            _numberBox.Update();
        }

        protected override void _attachOtherItemToForm(ref Control.ControlCollection control)
        {
            control.Add(_numberBox);
        }

        protected override void _setOtherItemPosition(Point p)
        {
            p.Y += DISTANCE;
            _numberBox.Location = p;
        }
    }
}
