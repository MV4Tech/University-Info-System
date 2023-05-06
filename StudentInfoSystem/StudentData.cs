using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
        public static List<Student> TestStudents = new List<Student>();

        static StudentData()
        {
            //TestStudents.Add();
        }
       /*
        public static Student student()
        {
           Student s1 = new Student();
 

            s1.name = "Mariqn";
            s1.surename = "Ivanov";
            s1.familyName = "Ivanov";
            s1.facultet = "FKST";
            s1.major = "KSI";
            s1.educDegree = "Bachelor";
            s1.status = "Active";
            s1.facultetNumber = 121220175;
            s1.course = "3";
            s1.stream = "10";
            s1.group = "43";

            return s1;

        }
       */
        public static Student IsThereStudent(string facNumb)
        {
            StudentInfoContext context
                    = new StudentInfoContext();
            Student result = (from st in context.Students
                          where st.facultetNumber.Equals(facNumb)
                          select st).First();
            if(result == null)
            {
                Console.WriteLine("error");
            }
            return result;
        }
    }
}

