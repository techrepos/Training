using Employee.Infrastructure.Data;
using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeContext empContext;

        public EmployeeRepository(EmployeeContext EmpContext)
        {
            empContext = EmpContext;
        }
        public int AddEmployee(EmployeeEntity Employee)
        {
             empContext.Employee.Add(Employee);
             empContext.SaveChanges();
            return Employee.Id;

        }

        public bool DeleteEmployee(int EmployeeId)
        {


            var employee = empContext.Employee.Find(EmployeeId);
            empContext.Employee.Remove(employee);
            if (empContext.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<EmployeeEntity> EmployeeList()
        {
            return empContext.Employee.ToList();

        }

        public EmployeeEntity GetEmployeeDetails(int Id)
        {
            return empContext.Employee.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public bool SaveEmployee(EmployeeEntity Employee)
        {

            var emp = empContext.Employee.Find(Employee.Id);
            if (emp != null)
            {
                emp.FirstName = Employee.FirstName;
                emp.LastName = Employee.LastName;
                emp.EmailAddress = Employee.EmailAddress;
                empContext.Update(emp);
                if (empContext.SaveChanges() > 0)
                    return true;
            }
            return false;
        }
    }
}
