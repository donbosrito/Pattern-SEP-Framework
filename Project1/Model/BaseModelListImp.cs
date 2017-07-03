using System.Data;

namespace SEPFramework.Model
{
    public abstract class BaseModelListImp<T> where T : BaseModel
    {
        public abstract T GetModel(int ID);
        public abstract void Add(T t);
        public abstract void Udpate(int position, T t);
        public abstract void Delete(int ID);
        public abstract DataTable Display();
        public abstract int Find(T model);
        public abstract void Clear();
        public abstract bool IsEmpty();
    }
}
