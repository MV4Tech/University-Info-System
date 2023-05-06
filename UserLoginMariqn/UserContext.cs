using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace UserLoginMariqn
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public UserContext() :base(Properties.Settings.Default.DbConnect)
        {

        }

    }
}
