using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class BaseModel
    {
        public int getPropertiesCount()
        {
            return this.GetType().GetProperties().Count();
        }

        public PropertyInfo getProperty(int position)
        {
            return this.GetType().GetProperties()[position];
        }
}
