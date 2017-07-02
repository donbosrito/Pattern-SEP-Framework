using SEPFramework.Service;

namespace SEPFramework.Model
{
    public class BaseModelList<T> where T : BaseModel, new()
    {
        private BaseModelListImp<T> data;
        public DBAdapter DBConnector { private get; set; }
        public BaseModelList()
        {
        }

        public void Initilization()
        {
            this.DBConnector.CreateTableIfNotExists(typeof(T));
        }

        public BaseModelListImp<T> GetAll()
        {
            data = this.DBConnector.FetchAllData<T>();
            return data;
        }

        public T GetById(int id)
        {
            return this.data.GetModel(id);
        }

        public void Add(T model)
        {
            this.DBConnector.AddModel<T>(model);
        }

        public bool Delete(T model)
        {
            return this.DBConnector.Delete<T>(model);
        }

        public bool Update(T old_model, T new_model)
        {
            return this.DBConnector.Update<T>(old_model, new_model);
        }

        public int Find(T model)
        {
            return this.data.Find(model);
        }

        public bool IsEmpty()
        {
            return this.data.IsEmpty();
        }
    }
}
