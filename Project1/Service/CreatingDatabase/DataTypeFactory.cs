using SEPFramework.Service.DataType;
using System.Collections.Generic;
using System.Reflection;

namespace SEPFramework.Service
{
    abstract class DataTypeFactory
    {
        protected List<DataType.DataType> lstDataType;

        public DataTypeFactory()
        {
        }

        public abstract string GenerateCreatePropertyQuery(PropertyInfo prop);

        public abstract string GetSqlValueString(PropertyInfo prop, object value);
    }
}
