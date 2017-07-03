using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLength : ModelAttribute
    {
        public int MaximumLength { get; set; }

        public StringLength()
        {
            MaximumLength = 1024;
            ErrorMessage = "This property must be a string with a maximum length of " + MaximumLength;
        }

        public StringLength(int maxLength)
        {
            MaximumLength = maxLength;
            ErrorMessage = "This property must be a string with a maximum length of " + MaximumLength;
        }

        public static int GetMaximumLength(PropertyInfo prop)
        {
            StringLength attr = (StringLength)prop.GetCustomAttribute(typeof(StringLength));
            if (attr == null)
                return (new StringLength()).MaximumLength;
            else return attr.MaximumLength;
        }
    }
}
