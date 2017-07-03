using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SEPFramework.Attribute;
using SEPFramework.Model;
using SEPFramework.Service.CreatingDatabase;

namespace SEPFramework.Service
{
    public class SqlAdapter: DBAdapter
    {
        private SqlConnection conn;
        private SqlDataReader reader;

        public SqlAdapter(string connectstring)
        {
            this.ConnectString = connectstring;
            var connectionStringBuilder = new SqlConnectionStringBuilder(this.ConnectString);
            this.DatabaseName = connectionStringBuilder.InitialCatalog;
            this.conn = new SqlConnection();
            this.reader = null;
            this.isConnect = false;
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

        public override void CreateDatabaseIfNotExists()
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

        public override void CreateTableIfNotExists(Type typeClass)
        {
            DataTypeFactory dataFactory = new SqlDataTypeFactory();
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

        public override BaseModelListImp<T> FetchAllData<T>()
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

        public override void AddModel<T>(T model)
        {
            DataTypeFactory dataFactory = new SqlDataTypeFactory();

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

        public override void UpdateModel<T>(T oldModel, T newModel)
        {
            DataTypeFactory dataFactory = new SqlDataTypeFactory();

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

        public override void DeleteModel<T>(T model)
        {
            DataTypeFactory dataFactory = new SqlDataTypeFactory();

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
        
        public override void Close()
        {
            reader = null;
            conn.Close();
            isConnect = false;
        }

        public void removeLastComma(ref string data)
        {
            if (data[data.Length - 1] == ',')
            {
                data = data.Remove(data.Length - 1, 1);
            }
        }
    }
}
