using SEPFramework.Attribute;
using SEPFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.Model
{
    public class ArrayList<T> : BaseModelListImp<T> where T : BaseModel
    {
        private List<T> data;

        public ArrayList()
        {
            this.data = new List<T>();
        }

        public ArrayList(List<T> data)
        {
            this.data = data;
        }

        public override void Add(T t)
        {
            data.Add(t);
        }

        public override void Delete(int ID)
        {
            data.RemoveAt(ID);
        }

        public override void Udpate(int position, T t)
        {
            data[position] = t;
        }

        public override DataTable Display()
        {
            DataTable dataTable = new DataTable();

            //Add columns
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var displayName = ((DisplayName)prop.GetCustomAttribute(typeof(DisplayName))).Name;
                if (displayName != null || displayName != "")
                {
                    dataTable.Columns.Add(displayName);
                } else
                {
                    dataTable.Columns.Add(prop.Name);
                }
            }

            //Add rows
            foreach (T item in data)
            {
                item.AttachToTable(ref dataTable);
            }

            return dataTable;
        }
    }
}
