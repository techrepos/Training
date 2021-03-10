using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee.Tests
{
    public class EmployeeRepositoryFake : IEmployeeRepository
    {
        List<EmployeeEntity> empFakeStore;
        public EmployeeRepositoryFake()
        {
            empFakeStore= new List<EmployeeEntity>
            {
                new EmployeeEntity { Id =1 , Name = "Amal", City = "Trvindrum", Worklocation = "India"},
                new EmployeeEntity { Id =2 , Name = "Dev", City = "Kochi", Worklocation = "India"},
                new EmployeeEntity { Id =3 , Name = "Tony", City = "New York", Worklocation = "US"},
                new EmployeeEntity { Id =4 , Name = "Allan", City = "London", Worklocation = "UK"},
                new EmployeeEntity { Id =5 , Name = "Sankar", City = "Delhi", Worklocation = "India"},
            };
        }
        public int AddEmployee(EmployeeEntity Employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeEntity> EmployeeList()
        {
            return empFakeStore;
        }

        public EmployeeEntity GetEmployeeDetails(int Id)
        {
            return empFakeStore.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public bool SaveEmployee(EmployeeEntity Employee)
        {
            throw new NotImplementedException();
        }
    }
}
