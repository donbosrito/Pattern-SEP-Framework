﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class BaseModelList<T> where T : BaseModel
    {
        BaseModelListImp<T> data;
    }
}
