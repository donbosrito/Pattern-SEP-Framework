using SEPFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Model
{
    public class Example : BaseModel
    {
        [ModelAttribute(DisplayName: "Name", Require:true)]
        public String Name { get; set; }

        [ModelAttribute(DisplayName: "Age", Require:false)]
        public int Age { get; set; }

        public Example(String Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
}
