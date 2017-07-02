using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.MemberShip
{
    public interface ICoder
    {
        string Encode(string data);
        string Decode(string data);
    }
}
