using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Uniqued : ModelAttribute
    {
        public bool IsUnique { get; set; }

        public Uniqued()
        {
            IsUnique = true;
            ErrorMessage = "This property must be uniqued";
        }

        public static bool check(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Uniqued)) != null && ((Uniqued)prop.GetCustomAttribute(typeof(Uniqued))).IsUnique;
        }
    }
}
