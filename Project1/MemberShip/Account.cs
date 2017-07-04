using SEPFramework.Attribute;
using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.MemberShip
{
    public enum MemberRoles
    {
        CanEdit, CanView, CanCreate
    }

    [Table("Account")]
    public class Account : BaseModel
    {
        [Required]
        [Key]
        public string Username { get; set; }

        [Key]
        public string Password {
            get
            {
                if (Account.Coders == null) return this.password;

                var temp = this.password;
                for (int i = Account.Coders.Count - 1; i >= 0; i--)
                {
                    temp = Account.Coders[i].Decode(temp);
                }

                return temp;
            }
            set
            {
                if (Account.Coders != null)
                {
                    var temp = value;
                    for (int i = 0; i < Account.Coders.Count; i++)
                    {
                        temp = Account.Coders[i].Encode(temp);
                    }

                    this.password = temp;
                }
                else
                {
                    this.password = value;
                }
            }
        }

        public string Role { get; set; }

        private string password = "";

        private static List<ICoder> Coders = null;
        public void setCoder(List<ICoder> coders)
        {
            Account.Coders = coders;
        }
    }
}
