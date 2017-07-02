using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.MemberShip
{
    public class AddingCoder: ICoder
    {
        public char Delta { get; set; }

        public AddingCoder(char delta)
        {
            this.Delta = delta;
        }

        string ICoder.Encode(string data)
        {
            var temp = data.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] += this.Delta;
            }
            var r = new string(temp);
            int n = r.Length;
            return r;
        }

        string ICoder.Decode(string data)
        {
            var temp = data.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] -= this.Delta;
            }

            return new string(temp);
        }
    }
}
