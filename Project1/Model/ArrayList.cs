using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Model
{
    public class ArrayList<T> : BaseModelListImp<T> where T : BaseModel
    {
        private List<T> data;

        public override void add(T t)
        {
            data.Add(t);
        }

        public override void delete(T t)
        {
            data.Remove(t);
        }

        public override void udpate(int position, T t)
        {
            data[position] = t;
        }

        public override void display()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
