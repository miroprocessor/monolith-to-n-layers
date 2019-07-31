using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Customertreatments1.Models;

namespace Customertreatments1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Customertreatments1.Models.applicatonuserviewmodel> applicatonuserviewmodel { get; set; }
    }
}
