using SEPFramework.Utils;
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

        public override void Delete(int index)
        {
            data.RemoveAt(index);
        }

        public override void Udpate(int position, T t)
        {
            data[position] = t;
        }

        public override DataTable Display()
        {
            DataTable dataTable = new DataTable();
            PropertyInfo[] lstPF = data[0].GetProperties();
            foreach (PropertyInfo pf in lstPF)
            {
                var attrs = pf.GetCustomAttributes();
                foreach (Attribute attr in attrs) // get each attribute using foreach
                {
                    if (attr is ModelAttribute)
                    {
                        ModelAttribute modelAttribute = (ModelAttribute)attr;
                        if (modelAttribute.Require)
                            dataTable.Columns.Add(modelAttribute.DisplayName + "*");
                        else
                            dataTable.Columns.Add(modelAttribute.DisplayName);
                        break;
                    }
                }
            }

            foreach (T item in data)
            {
                item.AttachToTable(ref dataTable);
            }

            return dataTable;
        }
    }
}
