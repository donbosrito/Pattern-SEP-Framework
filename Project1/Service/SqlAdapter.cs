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
            this.ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            catch (SqlException)
            {
                this.isConnect = false;
                return false;
            }
        }

        public void CreateDatabaseIfNotExists()
        {
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

            using (SqlCommand command = new SqlCommand(createQuery, conn))
            {
                command.ExecuteNonQuery();
            }
        }

        public BaseModelListImp<T> FetchAllData<T>() where T : BaseModel, new()
        {
            BaseModelListImp<T> lstModel = new ArrayList<T>();
            String query = "SELECT * FROM " + typeof(T).Name;
            SqlDataReader reader = new SqlCommand(query, this.conn).ExecuteReader();
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
            SqlDataReader reader = new SqlCommand(query, this.conn).ExecuteReader();
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


            removeLastComma(fields);
            removeLastComma(values);
            String query = "INSERT INTO " + Table.GetTableName(model.GetType()) + "(" + fields + ") VALUES (" + values + ")";
            new SqlCommand(query, this.conn).ExecuteNonQuery();
        }

        public string removeLastComma(string data)
        {
            if (data[data.Length - 1] == ',')
            {
                data.Remove(data.Length - 1, 1);
                return data;
            }
            return data;
        }

        public override void Close()
        {
            this.reader = null;
            this.conn.Close();
            this.isConnect = false;
        }

        public override bool ReadAllFromTable(string table)
        {
            if (!this.IsConnect()) return false;

            SqlCommand cmd = new SqlCommand("select * from " + table, this.conn);
            this.reader = cmd.ExecuteReader();

            return this.reader.HasRows;
        }

        public override List<object> Read()
        {
            List<object> result = new List<object>();

            if (this.reader.Read())
            {
                for (int i = 0; i < this.reader.FieldCount; i++)
                {
                    result.Add(this.reader[i]);
                }
            }

            return result;
        }

        public override List<string> GetColumnNames(string table)
        {
            if (!this.IsConnect()) this.Connect();

            List<String> columnNames = new List<string>();
            using (SqlCommand cmd = new SqlCommand("select column_name from information_schema.columns where table_name = '" + table + "'", this.conn))
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

            this.Close();
            return columnNames;
        }
    }
}
