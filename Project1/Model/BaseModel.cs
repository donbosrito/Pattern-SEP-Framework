using SEPFramework.Service;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using SEPFramework.Attribute;

namespace SEPFramework.Model
{
    public class BaseModel
    {
        //[Identity]
        //public int ID { get; }

        public int GetPropertiesCount()
        {
            return GetType().GetProperties().Count();
        }

        public PropertyInfo[] GetProperties()
        {
            var t = GetType().GetProperties(BindingFlags.Public
                                | BindingFlags.Instance
                                | BindingFlags.DeclaredOnly);
            return t;
        }

        public virtual bool Load(DBAdapter db)
        {
            List<object> objs = db.Read();

            if (objs.Count() == 0) return false;

            PropertyInfo[] props = GetType().GetProperties();
            int count = props.Length;

            for (int i = 0; i < count; i++)
            {
                props[i].SetValue(this, objs[i], null);
            }

            return true;
        }

        public void AttachToTable(ref DataTable table)
        {
            if (table == null) return;

            List<object> objs = new List<object>();
            PropertyInfo[] props = GetType().GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                objs.Add(props[i].GetValue(this, null));
            }

            table.Rows.Add(objs.ToArray());
        }

        public List<string> GetDisplayInfo()
        {
            List<string> names = new List<string>();

            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                var displayName = ((DisplayName)prop.GetCustomAttribute(typeof(DisplayName)));
                if (displayName != null && displayName.Name != "")
                {
                    names.Add(displayName.Name);
                }
                else
                {
                    names.Add(prop.Name);
                }
            }

            return names;
        }

        public bool ApplyProperties(object[] props_value)
        {
            var props = GetProperties();

            if (props.Length != props_value.Length) return false;

            for (int i = 0; i < props.Length; i++)
            {
                props[i].SetValue(this, props_value[i]);
            }

            return true;
        }

        public List<object> GetPropertiesValues()
        {
            List<object> values = new List<object>();

            var props = GetProperties();

            foreach (var p in props)
            {
                values.Add(p.GetValue(this));
            }

            return values;
        }
    }
}
