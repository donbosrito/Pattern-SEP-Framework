using System;
using System.Collections.Generic;
using SEPFramework.Model;

namespace SEPFramework.Service
{
    public abstract class DBAdapter
    {
        public string ConnectString { get; set; }
        public string DatabaseName { get; set; }
        protected bool isConnect;

        public abstract bool Connect();
        public abstract void Close();
        public abstract BaseModelListImp<T> FetchAllData<T>() where T : BaseModel, new();
        public abstract bool Delete<T>(BaseModel model) where T : BaseModel, new();
        public abstract bool Update<T>(BaseModel old_model, BaseModel new_model) where T : BaseModel, new();
        public abstract void CreateDatabaseIfNotExists();
        public abstract void CreateTableIfNotExists(Type typeClass);
        public abstract void AddModel<T>(T model) where T : BaseModel, new();

        public bool IsConnect()
        {
            return this.isConnect;
        }

    }
}
