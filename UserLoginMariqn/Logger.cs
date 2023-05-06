using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginMariqn
{
    public static class Logger
    {
        static public List<string> currentSessionActivities = new List<string>();
        public static Activities currActivities { get; set; }

        static public IEnumerable<string> LogActivity(Activities activity)
        {


            currActivities = activity;
            String output = "";
            switch (currActivities)
            {
                case (Activities)0:
                    output = "User has logged successfully.";
                    break;
                case (Activities)1:
                    output = "User role has been changed.";
                    break;
                case (Activities)2:
                    output = "User account has been changed to active.";
                    break;
                default:
                    output = "Something went wrong.";
                    break;
            }
            string activityLine = DateTime.Now + "; "
            + LoginValidation.currentUserRole + "; "
            + output + " ";
            currentSessionActivities.Add(activityLine);
            return currentSessionActivities;

        }

  
        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                              select activity).ToList();

            return filteredActivities;
        }
    }
    
}
