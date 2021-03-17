using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employee.Infrastructure.Entities;
namespace Employee.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> EmployeeList();
        Task<List<EmployeeEntity>> EmployeeList(EmployeeSearchParams searchParams);

        Task<EmployeeEntity> GetEmployeeDetails(int Id);
        Task<int> AddEmployee(EmployeeEntity Employee);
        Task<bool> SaveEmployee(EmployeeEntity Employee);
        Task<bool> DeleteEmployee(int employeeId);


        Task<List<EmployeePayments>> GetPaymentsByEmployee(int Id);
    }
}
