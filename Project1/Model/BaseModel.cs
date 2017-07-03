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
        public int GetPropertiesCount()
        {
            return GetType().GetProperties().Count();
        }

        public PropertyInfo[] GetProperties()
        {
            var t = GetType().GetProperties();
            return t;
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

        public bool EqualTo(BaseModel other)
        {
            var props = this.GetProperties();

            int count_nonKey = 0;
            for (int i = 0; i < this.GetPropertiesCount(); i++)
            {
                if (Key.check(props[i]))
                {
                    if (!props[i].GetValue(this).Equals(props[i].GetValue(other))) return false;
                }
                else
                {
                    count_nonKey++;
                }
            }

            if (count_nonKey == this.GetPropertiesCount())
            {
                if (props[0].GetValue(this) != props[0].GetValue(other)) return false;
            }
            return true;
        }
    }
}
