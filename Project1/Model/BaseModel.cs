using Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class BaseModel
    {
        public int getPropertiesCount()
        {
            return this.GetType().GetProperties().Count();
        }

        public PropertyInfo[] getProperties()
        {
            var t = this.GetType().GetProperties();
            return t;
        }

        public virtual bool load(DBAdapter db)
        {
            List<object> objs = db.read();

            if (objs.Count() == 0) return false;

            PropertyInfo[] props = this.GetType().GetProperties();
            int count = props.Length;

            for (int i = 0; i < count; i++)
            {
                props[i].SetValue(this, objs[i], null);
            }

            return true;
        }

        public void attachToTable(ref DataTable table)
        {
            if (table == null) return;

            List<object> objs = new List<object>();
            PropertyInfo[] props = this.GetType().GetProperties();
            int count = props.Length;

            for (int i = 0; i < count; i++)
            {
                objs.Add(props[i].GetValue(this, null));
            }

            table.Rows.Add(objs.ToArray());
        }
    }
}
