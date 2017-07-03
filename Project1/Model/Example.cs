using SEPFramework.Attribute;
using SEPFramework.Attributes;
using System;

namespace SEPFramework.Model
{
    [Table("Example")]
    public class Example : BaseModel
    {
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }

        [DisplayName("Gender")]
        [StringLength(3)]
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
