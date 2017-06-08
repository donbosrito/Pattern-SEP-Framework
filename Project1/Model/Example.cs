using SEPFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Model
{
    public class Example : BaseModel
    {
        [ModelAttribute(DisplayName = "Name", Require = true)]
        public String Name { get; set; }

        [ModelAttribute(DisplayName = "Age")]
        public int Age { get; set; }

        public Example() { }

        public Example(int ID, String Name, int Age)
        {
            base.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }
    }
}
