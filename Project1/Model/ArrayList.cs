using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Model
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

        public override void add(T t)
        {
            data.Add(t);
        }

        public override void delete(int index)
        {
            data.RemoveAt(index);
        }

        public override void udpate(int position, T t)
        {
            data[position] = t;
        }

        public override DataTable display()
        {
            DataTable dataTable = new DataTable();
            PropertyInfo[] lstPF = data[0].getProperties();
            foreach (PropertyInfo pf in lstPF)
            {
                dataTable.Columns.Add(pf.Name);
            }

            foreach (T item in data)
            {
                item.attachToTable(ref dataTable);
            }

            return dataTable;
        }
    }
}
