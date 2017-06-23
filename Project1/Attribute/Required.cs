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
