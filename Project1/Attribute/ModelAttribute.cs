using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class ModelAttribute : System.Attribute
    {
        public bool Identify { get; set; }
        public string DisplayName { get; set; }
        public bool Require { get; set; }
    }
}
