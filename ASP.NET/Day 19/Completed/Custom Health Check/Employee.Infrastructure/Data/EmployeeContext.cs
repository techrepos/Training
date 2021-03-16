using Employee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Infrastructure.Data
{
   public class EmployeeContext : DbContext
    {
        private ILoggerFactory _logger;
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<EmployeePayments> EmployeePayments { get; set; }
        public EmployeeContext(ILoggerFactory logger, DbContextOptions<EmployeeContext> options) : base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_logger);
        }

        public interface ILoggerFactory<T>
        {
        }
    }
}
