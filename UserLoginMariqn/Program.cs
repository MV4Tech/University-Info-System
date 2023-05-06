using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginMariqn
{
    
    class Program
    {

        public static string info(string inf)
        {
            return inf;
        }

        public delegate void ActionOnError(string errorMsg);
        public static void message(string error)
        {
            Console.WriteLine("!!!!!!" + error + "!!!!!!");
        }

        // Current Log Activity
        public static void currentLogActivity(string answer)
        {
            IEnumerable<string> list = Logger.GetCurrentSessionActivities(answer);
            StringBuilder sb = new StringBuilder();
            int c = 0;
            foreach (string str in list)
            {
                c++;
                sb.Append(c + ". " + str + "\n");
            }
            Console.WriteLine(sb.ToString());

        }

        // Log history
        public static void LogActivities()
        {
            //string message = " ";
            //IEnumerable<string> list = Logger.LogActivity(message);


            //list.ToList().Add(activityLine);

            // writing to a file test.txt
         
            StringBuilder sb = new StringBuilder();
           
            foreach (string str in Logger.currentSessionActivities)
            {
                sb.Append(str + "\n");
            }
            Console.WriteLine(sb.ToString());
            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("test.txt", sb.ToString() + "\n");
            }
            else
                Console.WriteLine("ERROR FILE NOT FOUND!");

            Console.WriteLine(sb.ToString());

        }


        // reading from a file
        public static void readLog()
        {
            if (File.Exists("test.txt") == true)
            {
                string s = File.ReadAllText("test.txt");
                Console.WriteLine(s);
            }
            else
                Console.WriteLine("ERROR FILE NOT FOUND!");
        }



        public static void adminMenu()
        {
            int choice;

            do
            {
            Console.WriteLine("Select an option: ");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Change role of the user.");
            Console.WriteLine("2. Change activity of the user.");
            Console.WriteLine("3. List of users.");
            Console.WriteLine("4. View log activity.");
            Console.WriteLine("5. Review current assessment.");
                
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    // exit
                    case 0:
                        Console.WriteLine("0. Exit");
                        break;

                    // Change role of the user.
                    case 1:
                        Console.WriteLine("Possible roles: 0.ANONYMOUS, 1.ADMIN, 2.INSPECTOR, 3.PROFESSOR, 4.STUDENT");
                        Console.Write("Select username of the user: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        // Console.Write("Select new role of the current user: ");
                        // string role = Console.ReadLine();
                        //UserRoles newRole = (UserRoles)Enum.Parse(typeof(UserRoles), role);
                        Console.Write("Select number for the new role: ");
                        int roleNumb = Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(id, (UserRoles)roleNumb);
                      //  Console.WriteLine("Successfully changed!");
                        //Console.WriteLine(UserData.TestUsers[1].role); 

                        break;

                    // Change activity of the user.
                    case 2:
                        Console.Write("Select username of the user: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose new expiry date for the current user: ");
                        Console.WriteLine("Please follow the form! - dd.mm.yyyy hh:mm:ss");
                        string date1 = Console.ReadLine();
                        DateTime dt = DateTime.Parse(date1);
                        UserData.SetUserActiveTo(id1, dt);
                       // Console.WriteLine("Successfully changed!");
                       // Console.WriteLine(UserData.TestUsers[1].expiryDate);
                        break;

                    case 3:
                        // list of all users
                        
                        break;

                    case 4:
                        //Logger for all activities
                        LogActivities();
                        readLog();
                        break;

                    case 5:
                        // Logger for currentActivity
                        Console.WriteLine("Enter what u are looking for: ");
                        string answer = Console.ReadLine();

                        currentLogActivity(answer); 
                        break;

                    default:
                        break;
                }
            } while (!(choice == 0 && choice == 2));
            
        }

        static void Main(string[] args)
        {

            User u1 = null;
           // Console.WriteLine("asd");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            //string error = "";
            ActionOnError ae = new ActionOnError(message);

            LoginValidation lv = new LoginValidation(username, password, message);
            if (lv.validateUserInput(ref u1))
            {
                
                // UserRoles u = u1.role;

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        //Console.Clear();
                        Console.WriteLine("\n---------------ACCOUNT STATUS---------------");
                        Console.WriteLine("ADMIN: " + u1.username);
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine(u1);
                        //Console.WriteLine(UserData.TestUsers[1].expiryDate);
                        
                        adminMenu();

                        break;
                    case UserRoles.ANONYMOUS:
                        //Console.Clear();
                        Console.WriteLine("\n---------------ACCOUNT STATUS---------------");
                        Console.WriteLine("ANONYMOUS: ");
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine(u1);
                        break;
                    case UserRoles.INSPECTOR:
                        Console.Clear();
                        Console.WriteLine("\n---------------ACCOUNT STATUS---------------");
                        Console.WriteLine("INSPECTOR: " + u1.username);
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine(u1);
                        break;
                    case UserRoles.PROFESSOR:
                        Console.Clear();
                        Console.WriteLine("\n---------------ACCOUNT STATUS---------------");
                        Console.WriteLine("PROFESSOR: " + u1.username);
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine(u1);
                        break;
                    case UserRoles.STUDENT:
                        Console.Clear();
                        Console.WriteLine("\n---------------ACCOUNT STATUS---------------");
                        Console.WriteLine("STUDENT: " + u1.username);
                        Console.WriteLine("--------------------------------------------\n");
                        Console.WriteLine(u1);
                        break;
                    default:
                        Console.WriteLine("No such a Role");
                        break;
                }

            }

        }
        

   
  

    }
}
