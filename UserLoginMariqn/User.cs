using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginMariqn
{
   public class User
    {
        public System.Int32 UserId { get; set; }
        public string username { get; set; }
         public string password { get; set; }
         public long facultetNumber { get; set; }
         public UserRoles role { get; set; }

        public System.DateTime? dateTime { get; set; }
        public System.DateTime? expiryDate { get; set; }




        public override string ToString()
        {
            return "Username: " + username + " \nPass: " + password + " \nFacultet Numb: " + facultetNumber + "\nDate of creation: " + dateTime;
        }

   
    }
}
