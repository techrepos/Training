using Employee.Infrastructure.Data;
using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeContext _dataContext{ get; set; }
        public static List<EmployeeEntity> EmpDataStore { get; set; }

        public EmployeeRepository(EmployeeContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> AddEmployee(EmployeeEntity Employee)
        {
        
            await _dataContext.Employee.AddAsync(Employee);
            await _dataContext.SaveChangesAsync();
            return Employee.Id;
        }

        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            var employee = _dataContext.Employee.Where(x => x.Id.Equals(EmployeeId)).FirstOrDefault();
            _dataContext.Employee.Remove(employee);
            if (await _dataContext.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        public async Task<List<EmployeeEntity>> EmployeeList()
        {
            return await _dataContext.Employee.ToListAsync();
        }

        public async Task<List<EmployeeEntity>> EmployeeList(EmployeeSearchParams searchParams)
        {
            var collection = _dataContext.Employee.ToList() as IEnumerable<EmployeeEntity>;
            if (!(searchParams.DeptId <= 0 && String.IsNullOrWhiteSpace(searchParams.Query)))
            {
                collection = await _dataContext.Employee.ToListAsync() as IEnumerable<EmployeeEntity>;

                if (searchParams.DeptId > 0)
                    collection = collection.Where(x => x.DepartmentId.Equals(searchParams.DeptId));
                if (!string.IsNullOrWhiteSpace(searchParams.Query))
                    collection = collection.Where(x => ((!String.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(searchParams.Query))
                    || (!String.IsNullOrWhiteSpace(x.PrimaryEmailAddress) && x.PrimaryEmailAddress.Contains(searchParams.Query))));
            }
            return collection
                .OrderBy(x => x.Id)
                .Skip((searchParams.PageNumber - 1) * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToList();

        }

        public async Task<EmployeeEntity> GetEmployeeDetails(int Id)
        {
            return await _dataContext.Employee.FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }

        public async Task<bool> SaveEmployee(EmployeeEntity Employee)
        {
            var emp = await _dataContext.Employee.FindAsync(Employee.Id);
            if (emp != null)
            {
                emp.Name = Employee.Name;
            //    emp.LastName = Employee.LastName;
                emp.PrimaryEmailAddress = Employee.PrimaryEmailAddress;
                _dataContext.Update(emp);
                if (await _dataContext.SaveChangesAsync() > 0)
                    return true;
            }
            return false;    
        }

        public async Task<List<EmployeePayments>> GetPaymentsByEmployee(int Id)
        {
            return await _dataContext.EmployeePayments.Where(x => x.EmployeeId.Equals(Id)).ToListAsync();
        }
    }
}
