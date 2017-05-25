using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class Example : BaseModel
    {
        private String name { get; set; }
        private int age { get; set; }

        public Example(String name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
