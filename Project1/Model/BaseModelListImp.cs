using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public abstract class BaseModelListImp<T> where T : BaseModel
    {
        public abstract void add(T t);
        public abstract void udpate(int position, T t);
        public abstract void delete(T t);
        public abstract void display();
    }
}
