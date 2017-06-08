using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEPFramework.Service
{
    public abstract class DBAdapter
    {
        public string connectString { get; set; }
        protected bool _isConnect;

        public abstract bool connect();
        public abstract void close();
        public abstract bool readAllFromTable(string table);
        public abstract List<object> read();
        public abstract List<String> getColumnNames(string table);

        public bool isConnect()
        {
            return this._isConnect;
        }
    }
}
