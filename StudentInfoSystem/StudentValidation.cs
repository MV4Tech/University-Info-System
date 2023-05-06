using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginMariqn;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
        


            if(user.facultetNumber != 9)
            {
                Console.WriteLine("There is no user with this facultet number");
                return null;
            }

            return new Student();

        }
    }
}
