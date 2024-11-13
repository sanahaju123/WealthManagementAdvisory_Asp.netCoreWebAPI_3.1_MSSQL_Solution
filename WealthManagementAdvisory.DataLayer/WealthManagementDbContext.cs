using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.DataLayer
{
    public class WealthManagementDbContext : DbContext
    {
        public WealthManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Advisory> Advisories { get; set; }
    }
}