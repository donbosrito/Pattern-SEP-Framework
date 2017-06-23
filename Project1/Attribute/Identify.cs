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
