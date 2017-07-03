using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Service.DataType;
using System.Reflection;

namespace SEPFramework.Service.CreatingDatabase
{
    class SqlDataTypeFactory : DataTypeFactory
    {
        List<DataType.DataType> lstDataType;

        public SqlDataTypeFactory()
        {
            lstDataType = new List<DataType.DataType>();
            lstDataType.Add(new SqlDecimal());
            lstDataType.Add(new SqlString());
            lstDataType.Add(new SqlDateTime());
            lstDataType.Add(new SqlInt());
            lstDataType.Add(new SqlDouble());
            lstDataType.Add(new SqlBoolean());
        }

        public override string GenerateCreatePropertyQuery(PropertyInfo prop)
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

        public override string GetSqlValueString(PropertyInfo prop, object value)
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
