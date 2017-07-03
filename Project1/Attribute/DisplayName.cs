using SEPFramework.Attributes;
using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : ModelAttribute
    {
        public string Name { get; set; }

        public DisplayName(String name)
        {
            Name = name;
        }

        public static string getName(PropertyInfo prop)
        {
            return ((DisplayName)prop.GetCustomAttribute(typeof(DisplayName))).Name;
        }
    }
}
