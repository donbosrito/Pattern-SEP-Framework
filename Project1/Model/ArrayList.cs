using SEPFramework.Attribute;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;

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

        public override T GetModel(int ID)
        {
            if (ID < 0 || ID >= this.data.Count) return null;

            return this.data[ID];
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
                var displayName = ((DisplayName)prop.GetCustomAttribute(typeof(DisplayName)));
                if (displayName != null && displayName.Name != null && displayName.Name != "")
                {
                    dataTable.Columns.Add(displayName.Name);
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

        public override int Find(T model)
        {
            if (model == null) return -1;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (model.EqualTo(this.data[i])) return i;
            }

            return -1;
        }

        public override void Clear()
        {
            if (this.data != null)
            {
                this.data.Clear();
            }
        }

        public override bool IsEmpty()
        {
            if (this.data == null || this.data.Count <= 0) return true;

            return false; 
        }
    }
}
