using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : System.Attribute
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
