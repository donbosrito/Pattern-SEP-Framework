using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SEPFramework.Service
{
    public class SqlAdapter: DBAdapter
    {
        private SqlConnection _conn;
        private SqlDataReader _reader;

        public SqlAdapter()
        {
            this._conn = new SqlConnection();
            this._reader = null;
            this.connectString = null;
            this._isConnect = false;
        }

        public override bool connect()
        {
            if (this.connectString == null) return false;

            this._conn.ConnectionString = this.connectString;
            this.close();

            try
            {
                this._conn.Open();
                this._isConnect = true;
                return true;
            }
            catch (SqlException)
            {
                this._isConnect = false;
                return false;
            }
        }

        public override void close()
        {
            this._reader = null;
            this._conn.Close();
            this._isConnect = false;
        }

        public override bool readAllFromTable(string table)
        {
            if (!this.isConnect()) return false;

            SqlCommand cmd = new SqlCommand("select * from " + table, this._conn);
            this._reader = cmd.ExecuteReader();

            return this._reader.HasRows;
        }

        public override List<object> read()
        {
            List<object> result = new List<object>();

            if (this._reader.Read())
            {
                for (int i = 0; i < this._reader.FieldCount; i++)
                {
                    result.Add(this._reader[i]);
                }
            }

            return result;
        }

        public override List<string> getColumnNames(string table)
        {
            if (!this.isConnect()) this.connect();

            List<String> columnNames = new List<string>();
            using (SqlCommand cmd = new SqlCommand("select column_name from information_schema.columns where table_name = '" + table + "'",
                                                    this._conn))
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

            this.close();
            return columnNames;
        }
    }
}
