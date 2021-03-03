using Employee.Infrastructure.Entities;
using System.Data;

namespace Employee.Infrastructure.Data
{
    public interface IEmployeeDataContext
    {
       

        DataTable GetEmployees(int EmployeeId =0    );
        int CreateEmployee(EmployeeEntity Employee);

        DataTable UpdateEmployee(EmployeeEntity Employee);

        bool DeleteEmployee(int EmployeeId);
    }
}