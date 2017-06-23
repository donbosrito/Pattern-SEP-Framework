using SEPFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class StringLength : ModelAttribute
    {
        public int MaximumLength { get; set; }

        public StringLength()
        {
            MaximumLength = 1024;
            ErrorMessage = "This property must be a string with a maximum length of " + MaximumLength;
        }

        public static int getMaximumLength(PropertyInfo prop)
        {
            StringLength attr = (StringLength)prop.GetCustomAttribute(typeof(StringLength));
            if (attr == null)
                return (new StringLength()).MaximumLength;
            else return attr.MaximumLength;
        }
    }
}
