using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class ModelAttribute : System.Attribute
    {
        public string DisplayName { get; set; }
        public bool Require { get; set; }

        public ModelAttribute()
        {
        }

        public ModelAttribute(string DisplayName, bool Require)
        {
            this.DisplayName = DisplayName;
            this.Require = Require;
        }
    }
}
