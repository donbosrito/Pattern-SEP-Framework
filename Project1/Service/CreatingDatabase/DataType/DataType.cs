﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Service.DataType
{
    abstract class DataType
    {
        public abstract string createInstance(PropertyInfo prop);
    }
}
