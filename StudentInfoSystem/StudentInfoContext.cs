using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserLoginMariqn;
namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {
         
        }
    }
}
