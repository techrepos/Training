using System;
using System.Collections.Generic;
using System.Text;
using Employee.Infrastructure.Entities;
namespace Employee.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeEntity> EmployeeList();
        EmployeeEntity GetEmployeeDetails(int Id);
        int AddEmployee(EmployeeEntity Employee);
        bool SaveEmployee(EmployeeEntity Employee);
        bool DeleteEmployee(int employeeId);
    }
}
