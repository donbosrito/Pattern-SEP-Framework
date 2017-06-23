using SEPFramework.Attribute;
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
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; } 

        public Example() { }

        public Example(String Name, int Age, string Gender)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
        }
    }
}
