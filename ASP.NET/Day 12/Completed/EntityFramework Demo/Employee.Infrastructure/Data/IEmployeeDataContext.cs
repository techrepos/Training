using Employee.Infrastructure.Entities;
using System.Data;

namespace Employee.Infrastructure.Data
{
    public interface IEmployeeDataContext
    {
        int CreateEmployee(EmployeeEntity Employee);
        bool DeleteEmployee(int EmployeeId);
        DataTable GetEmployees();
        DataTable UpdateEmployee(EmployeeEntity Employee);
    }
}