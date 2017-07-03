using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Identity : ModelAttribute
    {
        public bool IsIdentity { get; set; }

        public Identity()
        {
            IsIdentity = true;
            ErrorMessage = "This property must be identified";
        }

        public static bool check(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Identity)) != null && ((Identity)prop.GetCustomAttribute(typeof(Identity))).IsIdentity;
        }
    }
}
