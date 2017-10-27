using Flex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Flex.Core
{
    public class UserContext : DbContext
    {
        public UserContext() :base()
        {

        }

        public DbSet<User> User { get; set; }
    }
}