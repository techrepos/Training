using Employee.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Infrastructure.Entities;
namespace Employee.Tests
{
    public static class SeedData
    {
        public static void PopulateTestData(EmployeeContext dbContext)
        {
            dbContext.Employee.Add(new EmployeeEntity() {  Name = "Amal", City="Trivandrum", DepartmentId = 1});
            dbContext.Employee.Add(new EmployeeEntity() {  Name = "Dev", City = "London", DepartmentId = 1 });
            dbContext.SaveChanges();
        }
    }
}
