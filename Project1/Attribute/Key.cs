using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Key : ModelAttribute
    {
        public bool IsKey { get; set; }

        public Key()
        {
            IsKey = true;
            ErrorMessage = "This property must be primary key";
        }

        public static bool check(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Key)) != null && ((Key)prop.GetCustomAttribute(typeof(Key))).IsKey;
        }
    }
}
