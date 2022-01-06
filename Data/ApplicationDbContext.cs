using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dads_Site.Models;
using Dads_Site.Views;

namespace Dads_Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dads_Site.Models.Comic> Comic { get; set; }
        public DbSet<Dads_Site.Views.CDs> CDs { get; set; }
    }
}
