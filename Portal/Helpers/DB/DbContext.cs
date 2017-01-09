using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portal.Helpers.DB
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(string conn) : base(conn)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Grouping> Groupings { get; set; }

        public static PortalDbContext Get()
        {
            return new PortalDbContext(GlobalConstants.DB_CONNECTION_STRING);
        }
    }
}