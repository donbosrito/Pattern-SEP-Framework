using SEPFramework.Service.DataType;
using System.Collections.Generic;
using System.Reflection;

namespace SEPFramework.Service
{
    abstract class DataTypeFactory
    {
        List<DataType.DataType> lstDataType;

        public DataTypeFactory()
        {
            lstDataType = new List<DataType.DataType>();
            lstDataType.Add(new SqlDecimal());
            lstDataType.Add(new SqlString());
            lstDataType.Add(new SqlDateTime());
            lstDataType.Add(new SqlInt());
            lstDataType.Add(new SqlDouble());
            lstDataType.Add(new SqlBoolean());
        }

        public abstract string GenerateCreatePropertyQuery(PropertyInfo prop);

        public abstract string GetSqlValueString(PropertyInfo prop, object value);
    }
}
