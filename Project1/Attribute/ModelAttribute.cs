﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public abstract class ModelAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }

        public ModelAttribute()
        {
            ErrorMessage = "";
        }
    }
}
