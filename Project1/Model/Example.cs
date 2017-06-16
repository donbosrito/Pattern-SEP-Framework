using SEPFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.Model
{
    public enum Gender
    {
        Male, Female
    }

    public class Example : BaseModel
    {
        [ModelAttribute(DisplayName = "Name", Require = true)]
        public String Name { get; set; }

        [ModelAttribute(DisplayName = "Age")]
        public int Age { get; set; }

        [ModelAttribute(DisplayName = "Gender")]
        public Gender gender { get; set; }

        public Example() { }

        public Example(String Name, int Age, Gender g)
        {
            this.Name = Name;
            this.Age = Age;
            this.gender = g;
        }
    }
}
