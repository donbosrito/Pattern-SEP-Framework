using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SEPFramework.Model
{
    public class Example : BaseModel
    {
        public String name { get; set; }
        public int age { get; set; }

        public Example(String name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
