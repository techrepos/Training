using System;
using System.Collections.Generic;
using System.Text;
using Employee.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeEntity> EmployeeList();

        List<EmployeeEntity> EmployeeList(int DepartmentId, string Query);
        EmployeeEntity GetEmployeeDetails(int Id);
        int AddEmployee(EmployeeEntity Employee);
        bool SaveEmployee(EmployeeEntity Employee);
        bool DeleteEmployee(int employeeId);
        List<EmployeePayments> PaymentList();
        List<EmployeePayments> GetPaymentsByEmployee(int Id);

        int AddEmployeePayment(EmployeePayments Payment);
    }
}
