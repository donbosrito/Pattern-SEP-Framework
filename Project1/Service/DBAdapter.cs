using System;
using System.Collections.Generic;

namespace SEPFramework.Service
{
    public abstract class DBAdapter
    {
        public string ConnectString { get; set; }
        public string DatabaseName { get; set; }
        protected bool isConnect;

        public abstract bool Connect();
        public abstract void Close();
        public abstract bool ReadAllFromTable(string table);
        public abstract List<object> Read();
        public abstract List<String> GetColumnNames(string table);

        public bool IsConnect()
        {
            return this.isConnect;
        }

    }
}
