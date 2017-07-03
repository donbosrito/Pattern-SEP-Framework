using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SEPFramework.Attribute;
using SEPFramework.Model;

namespace SEPFramework.Service
{
    public class SqlAdapter: DBAdapter
    {
        private SqlConnection conn;
        private SqlDataReader reader;

        public SqlAdapter()
        {
            ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connectionStringBuilder = new SqlConnectionStringBuilder(ConnectString);
            DatabaseName = connectionStringBuilder.InitialCatalog;
            conn = new SqlConnection();
            reader = null;
            isConnect = false;
        }

        public override bool Connect()
        {
            if (ConnectString == null) return false;

            conn.ConnectionString = ConnectString;
            Close();

            try
            {
                CreateDatabaseIfNotExists();
                conn.Open();
                isConnect = true;
                return true;
            }
            catch (SqlException)
            {
                isConnect = false;
                return false;
            }
        }

        public void CreateDatabaseIfNotExists()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(ConnectString);
            connectionStringBuilder.InitialCatalog = "master";

            var connection = new SqlConnection(connectionStringBuilder.ToString());
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM master.dbo.sysdatabases WHERE name='{0}'", DatabaseName);

            var reader = command.ExecuteReader();
            if (reader.HasRows) // exists
                return;

            reader.Close();

            command.CommandText = string.Format("CREATE DATABASE {0}", DatabaseName);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void CreateTableIfNotExists(Type typeClass)
        {
            DataTypeFactory dataFactory = new DataTypeFactory();
            string createQuery = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = N'" + typeClass.Name + "' AND XTYPE = 'U')" +
                " CREATE TABLE " + typeClass.Name + " (";

            List<string> lstFieldQuery = new List<string>();
            List<string> lstKey = new List<string>();
            foreach (PropertyInfo prop in typeClass.GetProperties())
            {
                lstFieldQuery.Add(dataFactory.GenerateCreatePropertyQuery(prop));
                if (Key.check(prop))
                {
                    lstKey.Add(prop.Name);
                }
            }

            if (lstKey.Count > 0)
            {
                lstFieldQuery.Add("PRIMARY KEY (" + string.Join(", ", lstKey) + ")");
            } else
            {
                //Set default key
                lstFieldQuery.Add("PRIMARY KEY (" + typeClass.GetProperties()[0].Name + ")");
            }

            createQuery += string.Join(", ", lstFieldQuery) + ")";

            new SqlCommand(createQuery, conn).ExecuteNonQuery();
        }

        public BaseModelListImp<T> FetchAllData<T>() where T : BaseModel, new()
        {
            BaseModelListImp<T> lstModel = new ArrayList<T>();
            String query = "SELECT * FROM " + typeof(T).Name;
            SqlDataReader reader = new SqlCommand(query, conn).ExecuteReader();
            while (reader.Read())
            {
                T model = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                lstModel.Add(model);
            }
            reader.Close();
            return lstModel;
        }

        public T FetchDataById<T>(int Id) where T : BaseModel, new()
        {
            T model = new T();
            String query = "SELECT * FROM " + Table.GetTableName(model.GetType()) + " WHERE ID = " + Id;
            SqlDataReader reader = new SqlCommand(query, conn).ExecuteReader();
            while (reader.Read())
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                reader.Close();
                return model;
            }
            reader.Close();
            return null;
        }

        public void AddModel<T>(T model) where T : BaseModel, new()
        {
            DataTypeFactory dataFactory = new DataTypeFactory();

            String fields = "", values = "";
            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                if (!Uniqued.check(prop))
                {
                    fields += prop.Name + ",";
                    values += dataFactory.GetSqlValueString(prop, prop.GetValue(model)) + ",";
                }
            }

            removeLastComma(ref fields);
            removeLastComma(ref values);
            string query = "INSERT INTO " + Table.GetTableName(model.GetType()) + "(" + fields + ") VALUES (" + values + ")";
            new SqlCommand(query, conn).ExecuteNonQuery();
        }

        public void UpdateModel<T>(T oldModel, T newModel) where T : BaseModel, new()
        {
            DataTypeFactory dataFactory = new DataTypeFactory();

            String fieldsUpdate = "";
            String whereUpdate = "";
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (!Uniqued.check(prop))
                {
                    fieldsUpdate += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(newModel)) + ",";
                }
                if (Key.check(prop))
                {
                    if (whereUpdate == "")
                        whereUpdate += " WHERE ";
                    else whereUpdate += " AND ";
                    whereUpdate += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(oldModel));
                }
            }

            removeLastComma(ref fieldsUpdate);
            String query = "UPDATE " + Table.GetTableName(typeof(T)) + " SET " + fieldsUpdate + whereUpdate;
            new SqlCommand(query, conn).ExecuteNonQuery();
        }

        public void DeleteModel<T>(T model) where T : BaseModel, new()
        {
            DataTypeFactory dataFactory = new DataTypeFactory();

            string whereUpdate = "";
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (Key.check(prop))
                {
                    if (whereUpdate == "")
                        whereUpdate += " WHERE ";
                    else whereUpdate += " AND ";
                    whereUpdate += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(model));
                }
            }

            String query = "DELETE FROM " + Table.GetTableName(typeof(T)) + whereUpdate;
            new SqlCommand(query, conn).ExecuteNonQuery();
        }

        public void removeLastComma(ref string data)
        {
            if (data[data.Length - 1] == ',')
            {
                data = data.Remove(data.Length - 1, 1);
            }
        }

        public override void Close()
        {
            reader = null;
            conn.Close();
            isConnect = false;
        }

        public override bool ReadAllFromTable(string table)
        {
            if (!IsConnect()) return false;

            SqlCommand cmd = new SqlCommand("select * from " + table, conn);
            reader = cmd.ExecuteReader();

            return reader.HasRows;
        }

        public override List<object> Read()
        {
            List<object> result = new List<object>();

            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result.Add(reader[i]);
                }
            }

            return result;
        }

        public override List<string> GetColumnNames(string table)
        {
            if (!IsConnect()) Connect();

            List<String> columnNames = new List<string>();
            using (SqlCommand cmd = new SqlCommand("select column_name from information_schema.columns where table_name = '" + table + "'", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var sch_table = reader.GetSchemaTable();
                    foreach (DataColumn c in sch_table.Columns)
                    {
                        columnNames.Add(c.ColumnName);
                    }
                }
            }

            Close();
            return columnNames;
        }
    }
}
