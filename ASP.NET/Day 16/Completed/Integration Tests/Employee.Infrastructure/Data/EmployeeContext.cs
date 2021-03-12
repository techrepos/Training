using Employee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Infrastructure.Data
{
   public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Country> Country { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                 .HasKey(c => new { c.Code, c.Name });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }




    }
}
