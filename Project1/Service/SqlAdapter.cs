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

        public SqlAdapter()
        {
            this.ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connectionStringBuilder = new SqlConnectionStringBuilder(this.ConnectString);
            this.DatabaseName = connectionStringBuilder.InitialCatalog;
            this.conn = new SqlConnection();
            this.reader = null;
            this.isConnect = false;
        }

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
            if (this.ConnectString == null) return false;

            this.conn.ConnectionString = this.ConnectString;
            this.Close();

            try
            {
                CreateDatabaseIfNotExists();
                this.conn.Open();
                this.isConnect = true;
                return true;
            }
            catch (SqlException e)
            {
                this.isConnect = false;
                return false;
            }
        }

        public override void CreateDatabaseIfNotExists()
        {
            this._closeReader();
            var connectionStringBuilder = new SqlConnectionStringBuilder(this.ConnectString);
            connectionStringBuilder.InitialCatalog = "master";

            using (var connection = new SqlConnection(connectionStringBuilder.ToString()))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM master.dbo.sysdatabases WHERE name='{0}'", DatabaseName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // exists
                            return;
                    }

                    command.CommandText = string.Format("CREATE DATABASE {0}", this.DatabaseName);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
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

            this._closeReader();
            using (SqlCommand command = new SqlCommand(createQuery, conn))
            {
                command.ExecuteNonQuery();
            }
        }

        public override BaseModelListImp<T> FetchAllData<T>()
        {
            BaseModelListImp<T> lstModel = new ArrayList<T>();
            String query = "SELECT * FROM " + typeof(T).Name;

            this._closeReader();
            reader = new SqlCommand(query, this.conn).ExecuteReader();
            while (reader.Read())
            {
                T model = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                lstModel.Add(model);
            }
            return lstModel;
        }

        public T FetchDataById<T>(int Id) where T : BaseModel, new()
        {
            T model = new T();
            String query = "SELECT * FROM " + Table.GetTableName(model.GetType()) + " WHERE ID = " + Id;

            this._closeReader();
            this.reader = new SqlCommand(query, this.conn).ExecuteReader();
            while (reader.Read())
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                return model;
            }
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
            String query = "INSERT INTO " + Table.GetTableName(model.GetType()) + "(" + fields + ") VALUES (" + values + ")";

            this._closeReader();
            new SqlCommand(query, this.conn).ExecuteNonQuery();
        }

        public override bool Delete<T>(BaseModel model)
        {
            if (model == null) return false;

            DataTypeFactory dataFactory = new SqlDataTypeFactory();
            String condition = "";
            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                if (!Uniqued.check(prop))
                {
                    condition += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(model)) + " and ";
                }
            }

            condition = condition.Remove(condition.Length - 4, 3);
            string query = "DELETE FROM " + Table.GetTableName(model.GetType()) +
                " WHERE " + condition;
            this._closeReader();
            new SqlCommand(query, this.conn).ExecuteNonQuery();

            return true;
        }

        public override bool Update<T>(BaseModel old_model, BaseModel new_model)
        {
            if (old_model == null || new_model == null) return false;

            DataTypeFactory dataFactory = new SqlDataTypeFactory();
            String condition = "", set = "";

            //Create condition
            foreach (PropertyInfo prop in old_model.GetType().GetProperties())
            {
                if (!Uniqued.check(prop))
                {
                    condition += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(old_model)) + " and ";
                }
            }

            //Create set
            foreach (PropertyInfo prop in new_model.GetType().GetProperties())
            {
                if (!Uniqued.check(prop))
                {
                    set += prop.Name + " = " + dataFactory.GetSqlValueString(prop, prop.GetValue(new_model)) + ",";
                }
            }

            this.removeLastComma(ref set);
            condition = condition.Remove(condition.Length - 4, 3);
            string query = "UPDATE " + Table.GetTableName(old_model.GetType()) +
                " SET " + set + 
                " WHERE " + condition;

            this._closeReader();
            new SqlCommand(query, this.conn).ExecuteNonQuery();

            return true;
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
            this.reader = null;
            this.conn.Close();
            this.isConnect = false;
        }

        private void _closeReader()
        {
            if (this.reader != null && !this.reader.IsClosed) reader.Close();
        }
    }
}
