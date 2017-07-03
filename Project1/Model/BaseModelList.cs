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

        public void Delete(T model)
        {
            this.DBConnector.DeleteModel<T>(model);
        }

        public void Update(T oldModel, T newModel)
        {
            this.DBConnector.UpdateModel<T>(oldModel, newModel);
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
