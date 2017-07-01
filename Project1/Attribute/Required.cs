using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : ModelAttribute
    {
        public bool IsRequire { get; set; }

        public Required()
        {
            IsRequire = true;
            ErrorMessage = "This property must be required";
        }

        public static bool check(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Required)) != null && ((Required)prop.GetCustomAttribute(typeof(Required))).IsRequire;
        }
    }
}
