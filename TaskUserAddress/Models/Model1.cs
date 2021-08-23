using System;
using System.Data.Entity;
using System.Linq;

namespace TaskUserAddress.Models
{
    public class Model1 : DbContext
    {
      
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
    }

  
}