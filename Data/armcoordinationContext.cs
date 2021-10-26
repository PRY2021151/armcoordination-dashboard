using armcoordination_dashboard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Data
{
    public class armcoordinationContext : IdentityDbContext<ApplicationUser>
    {

        public armcoordinationContext(DbContextOptions<armcoordinationContext> options)
            : base(options)
        {
        
        }

        // TODO: Entities
        public DbSet<children> child { get; set; }
        public DbSet<session> session { get; set; }
        //public DbSet<Kids> Kids { get; set; }
        public DbSet<armcoordination_dashboard.Models.ChildModel> ChildModel { get; set; }
    }
}
