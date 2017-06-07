using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SEPFramework.Model
{
    public abstract class BaseModelListImp<T> where T : BaseModel
    {
        public abstract void add(T t);
        public abstract void udpate(int position, T t);
        public abstract void delete(int index);
        public abstract DataTable display();
    }
}
