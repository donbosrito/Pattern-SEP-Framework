using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisplayName : System.Attribute
    {
        public string Name { get; set; }

        public DisplayName(String name)
        {
            Name = name;
        }
    }
}
