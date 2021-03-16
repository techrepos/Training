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
        public EmployeeContext _dataContext { get; set; }
        public static List<EmployeeEntity> EmpDataStore { get; set; }

        public EmployeeRepository(EmployeeContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddEmployee(EmployeeEntity Employee)
        {
            _dataContext.Employee.Add(Employee);
            _dataContext.SaveChanges();
            return Employee.Id;
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            var employee = _dataContext.Employee.Where(x => x.Id.Equals(EmployeeId)).FirstOrDefault();
            _dataContext.Employee.Remove(employee);
            if (_dataContext.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<EmployeeEntity> EmployeeList()
        {
            return _dataContext.Employee.ToList();
        }

        public List<EmployeeEntity> EmployeeList(int DepartmentId)
        {
            if(DepartmentId <= 0  )
                return _dataContext.Employee.ToList();



            return _dataContext.Employee.Where(x => x.DepartmentId.Equals(DepartmentId)).ToList();
         
        }
        public EmployeeEntity GetEmployeeDetails(int Id)
        {
            return _dataContext.Employee.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public bool SaveEmployee(EmployeeEntity Employee)
        {
            var emp = _dataContext.Employee.Find(Employee.Id);
            if (emp != null)
            {
                emp.Name = Employee.Name;
                //    emp.LastName = Employee.LastName;
                emp.PrimaryEmailAddress = Employee.PrimaryEmailAddress;
                _dataContext.Update(emp);
                if (_dataContext.SaveChanges() > 0)
                    return true;
            }
            return false;
        }

        public List<EmployeePayments> PaymentList()
        {
            return _dataContext.EmployeePayments.ToList();
        }

        public List<EmployeePayments> GetPaymentsByEmployee(int Id)
        {
            return _dataContext.EmployeePayments.Where(x => x.EmployeeId.Equals(Id)).ToList();
        }

        public int AddEmployeePayment( EmployeePayments Payment)
        {
          
            _dataContext.EmployeePayments.Add(Payment);
            _dataContext.SaveChanges();
            return Payment.Id;
        }
    }
}
