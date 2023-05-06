using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginMariqn
{
   public static class UserData
    {


        //public static User[] testUsers;
        public static List<User> testUsers;
        
        private static void ResetTestUserData()
        {
            if(testUsers == null)
            {


                testUsers = new List<User>();
                
                User u1 = new User();
                u1.username = "Asdtoemanqk";
                u1.password = "Asdtoetapak";
                u1.facultetNumber = 121220175;
                u1.role = UserRoles.ADMIN;
                u1.dateTime = DateTime.Now;
                u1.expiryDate = DateTime.MaxValue;
                testUsers.Add(u1);

                User u2 = new User();
                u2.username = "MachkaiNafta";
                u2.password = "Asdtoetapak";
                u2.facultetNumber = 121220174;
                u2.role = UserRoles.STUDENT;
                u2.dateTime = DateTime.Now;
                u2.expiryDate = DateTime.MaxValue;
                testUsers.Add(u2);

                User u3 = new User();
                u3.username = "Chernomoretz";
                u3.password = "Asdtoetapak";
                u3.facultetNumber = 121220143;
                u3.role = UserRoles.STUDENT;
                u3.dateTime = DateTime.Now;
                u3.expiryDate = DateTime.MaxValue;
                testUsers.Add(u3);

            }

        }

        public static List<User> TestUsers
        {
            get { ResetTestUserData(); return testUsers; }
            private set { }
        }

        public static User isUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();
            List<User> linqList = (from users in context.Users
                                  where users.username.Equals(username)
                                  && users.password.Equals(password)
                                  select users).ToList();

            if(linqList.Count() > 0)
            {

             return linqList[0];
            }
                
                
            return null;
        }

        public static void SetUserActiveTo(int userid, DateTime newDateActivity)
        {
            UserContext context = new UserContext();
            User usr = (from us in context.Users
                        where us.UserId == userid
                        select us).First();
            usr.expiryDate = newDateActivity;
            context.SaveChanges();
                    Logger.LogActivity(Activities.USER_ACTIVE_TO_CHANGED);

            /*
            foreach (User u in TestUsers)
            {
                if (u.username.Equals(username))
                {
                    u.expiryDate = newDateActivity;
                    //Logger.LogActivity("Activity chanegd to " + username);
                }
            }
            */
        }

        public static void AssignUserRole(int userid, UserRoles role)
        {
            UserContext context = new UserContext();
            User usr = new User();
             usr = (from us in context.Users
                        where us.UserId == userid
                        select us).FirstOrDefault();
            if(usr == null)
            {
                Console.WriteLine("not found");
            }
            usr.role = role;
            context.SaveChanges();
                    Logger.LogActivity(Activities.USER_CHANGED);
            /*
            foreach (User u in TestUsers)
            {
                if (u.username.Equals(username))
                {
                    u.role = role;
                    //Logger.LogActivity("Changed Role to " + username);
                }
            }
            */
        }

    }
}
