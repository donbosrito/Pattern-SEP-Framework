using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SEPFramework.Model
{
    public class BaseModelList<T> where T : BaseModel
    {
        BaseModelListImp<T> data;
    }
}
