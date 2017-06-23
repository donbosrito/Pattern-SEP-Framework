using SEPFramework.Service.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public string generatePropertyQuery(PropertyInfo prop)
        {
            foreach (var dataType in lstDataType)
            {
                var query = dataType.createInstance(prop);

                if (query != "")
                {
                    return query;
                }
            }
            return "";
        }
    }
}
