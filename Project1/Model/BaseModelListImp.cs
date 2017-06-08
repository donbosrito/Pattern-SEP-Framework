using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Model
{
    public abstract class BaseModelListImp<T> where T : BaseModel
    {
        public abstract void Add(T t);
        public abstract void Udpate(int position, T t);
        public abstract void Delete(int index);
        public abstract DataTable Display();
    }
}
