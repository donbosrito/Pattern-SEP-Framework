using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SEPFramework.Model
{
    public enum Gender
    {
        Male, Female
    };

    public class Example : BaseModel
    {
        public String name { get; set; }
        public Gender gender { get; set; }
        public DateTime date { get; set; }

        public Example()
        {
            name = "";
            gender = Gender.Male;
            date = new DateTime();
        }

        public Example(String name, Gender g, DateTime d)
        {
            this.name = name;
            this.gender = g;
            date = d;
        }
    }
}
