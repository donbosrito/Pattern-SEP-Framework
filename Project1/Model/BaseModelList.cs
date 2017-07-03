namespace SEPFramework.Model
{
    public class BaseModelList<T> where T : BaseModel, new()
    {
        BaseModelListImp<T> data;
        public BaseModelList()
        {
            DatabaseVariable.value.CreateTableIfNotExists(typeof(T));
        }

        public BaseModelListImp<T> GetAll()
        {
            return DatabaseVariable.value.FetchAllData<T>();
        }

        public T GetById(int id)
        {
            return DatabaseVariable.value.FetchDataById<T>(id);
        }

        public void Add(T model)
        {
            DatabaseVariable.value.AddModel<T>(model);
        }

        public void Update(T oldModel, T newModel)
        {
            DatabaseVariable.value.UpdateModel<T>(oldModel, newModel);
        }

        public void Delete(T model)
        {
            DatabaseVariable.value.DeleteModel<T>(model);
        }
    }
}
