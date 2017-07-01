using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Identify : ModelAttribute
    {
        public bool IsIdentify { get; set; }

        public Identify()
        {
            IsIdentify = true;
            ErrorMessage = "This property must be identified";
        }

        public static bool check(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Identify)) != null && ((Identify)prop.GetCustomAttribute(typeof(Identify))).IsIdentify;
        }
    }
}
