using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Names { get; set; }
        public string LastName { get; set; }
        public string PasswordText { get; set; }
    }
}
