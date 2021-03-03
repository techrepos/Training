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
        public IEmployeeDataContext _dataContext{ get; set; }
        public static List<EmployeeEntity> EmpDataStore { get; set; }

        public EmployeeRepository(IEmployeeDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddEmployee(EmployeeEntity Employee) => _dataContext.CreateEmployee(Employee);

        public bool DeleteEmployee(int EmployeeId)
        {
            if (EmpDataStore.Count > 0)
            {

                EmpDataStore.Remove(EmpDataStore.Where(x => x.Id.Equals(EmployeeId)).First());
                return true;
            }

            return false;
        }

        public List<EmployeeEntity> EmployeeList()
        {
            DataTable dtEmployee = _dataContext.GetEmployees();
            List<EmployeeEntity> data = dtEmployee.AsEnumerable()
                .Select(x =>
                new EmployeeEntity
                {
                    Id = x.Field<Int32>("Id"),
                    FirstName = x.Field<String>("FirstName"),
                    LastName = x.Field<String>("LastName"),
                    EmailAddress = x.Field<String>("EmailAddress"),
                    Country = x.Field<String>("Country"),
                }).ToList();
            return data ?? new List<EmployeeEntity>();
        }

        public EmployeeEntity GetEmployeeDetails(int Id)
        {
            DataTable dtEmployee = _dataContext.GetEmployees(Id);
            EmployeeEntity data = dtEmployee.AsEnumerable()
                .Select(x =>
                new EmployeeEntity
                {
                    Id = x.Field<Int32>("Id"),
                    FirstName = x.Field<String>("FirstName"),
                    LastName = x.Field<String>("LastName"),
                    EmailAddress = x.Field<String>("EmailAddress"),
                    Country = x.Field<String>("Country"),
                }).FirstOrDefault();
            return data ?? new EmployeeEntity();
        }

        public bool SaveEmployee(EmployeeEntity Employee)
        {
            if (EmpDataStore.Count > 0)
            {
                var itm = EmpDataStore.Where(x => x.Id.Equals(Employee.Id)).FirstOrDefault();
                if (itm != null)
                {
                    EmpDataStore.Remove(itm);
                    EmpDataStore.Add(Employee);
                    return true;
                }
            }
            return false;
        }
    }
}
