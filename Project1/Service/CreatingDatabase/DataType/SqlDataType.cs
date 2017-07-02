using SEPFramework.Attribute;
using System;
using System.Reflection;

namespace SEPFramework.Service.DataType
{
    class SqlInt : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(Int32) || prop.PropertyType == typeof(Int32?))
            {
                var query = prop.Name + " INT";

                //Check require attribute
                if (Identify.check(prop))
                {
                    query += " IDENTIFY";
                }

                //Check require attribute
                if (prop.PropertyType == typeof(Int32) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }
                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(Int32) || value.GetType() == typeof(Int32?))
            {
                if (value != null)
                {
                    return value.ToString();
                }
                else return "NULL";
            }
            return "";
        }
    }

    class SqlString : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(String))
            {                
                //Check string length attribute
                var query = prop.Name + " NVARCHAR(" + StringLength.getMaximumLength(prop) + ")";

                //Check require attribute
                if (Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }

                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(String))
            {
                if (value != null)
                {
                    return "N'" + value.ToString() + "'";
                }
                else return "NULL";
            } return "";
        }
    }

    class SqlDouble : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(Double) || prop.PropertyType == typeof(float) || prop.PropertyType == typeof(Double?) || prop.PropertyType == typeof(float))
            {
                var query = prop.Name + " FLOAT";

                //Check require attribute
                if (prop.PropertyType == typeof(Double) || prop.PropertyType == typeof(float) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }

                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(Double) || value.GetType() == typeof(float) || value.GetType() == typeof(Double?) || value.GetType() == typeof(float))
            {
                if (value != null)
                {
                    return value.ToString();
                }
                else return "NULL";
            }
            return "";
        }
    }

    class SqlDecimal : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(Decimal) || prop.PropertyType == typeof(Decimal?))
            {
                var query = prop.Name + " DECIMAL";

                //Check require attribute
                if (prop.PropertyType == typeof(Decimal) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }

                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(Decimal) || value.GetType() == typeof(Decimal?))
            {
                if (value != null)
                {
                    return value.ToString();
                }
                else return "NULL";
            } return "";
        }
    }

    class SqlDateTime : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
            {
                var query = prop.Name + " DATETIME";

                //Check require attribute
                if (prop.PropertyType == typeof(DateTime) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }

                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(DateTime) || value.GetType() == typeof(DateTime?))
            {
                if (value != null)
                {
                    return "'" + value.ToString() + "'";
                }
                else return "NULL";
            }
            return "";
        }
    }

    class SqlBoolean : DataType
    {
        public override string GenerateCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(Boolean) || prop.PropertyType == typeof(Boolean?))
            {
                var query = prop.Name + " BOOLEAN";

                //Check require attribute
                if (prop.PropertyType == typeof(Boolean) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                //Check unique attribute
                if (Uniqued.check(prop))
                {
                    query += " UNIQUE";
                }

                return query;
            }

            return "";
        }

        public override string GenerateSQLValue(object value)
        {
            if (value.GetType() == typeof(Boolean) || value.GetType() == typeof(Boolean?))
            {
                if (value != null)
                {
                    if (((bool)value) == true)
                        return "TRUE";
                    return "FALSE";
                }
                else return "NULL";
            } return "";
        }
    }
}
