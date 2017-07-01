using SEPFramework.Service.DataType;
using System.Collections.Generic;
using System.Reflection;

namespace SEPFramework.Service
{
    class DataTypeFactory
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

        public string GenerateCreatePropertyQuery(PropertyInfo prop)
        {
            foreach (var dataType in lstDataType)
            {
                var query = dataType.GenerateCreateQuery(prop);

                if (query != "")
                {
                    return query;
                }
            }
            return "";
        }

        public string GetSqlValueString(PropertyInfo prop, object value)
        {
            foreach (var dataType in lstDataType)
            {
                var query = dataType.GenerateSQLValue(value);

                if (query != "")
                {
                    return query;
                }
            }
            return "";
        }
    }
}
