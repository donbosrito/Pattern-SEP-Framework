using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.SEPControl
{
    public interface IControl <T> where T : BaseModel, new()
    {
        void start();
    }
}
