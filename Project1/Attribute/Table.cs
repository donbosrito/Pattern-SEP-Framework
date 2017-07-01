using System;
using System.Reflection;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : System.Attribute
    {
        public string Name { get; set; }

        public Table(String name)
        {
            Name = name;
        }

        public static string GetTableName(Type type)
        {
            return ((Table)type.GetCustomAttribute(typeof(Table))).Name;
        }
    }
}
