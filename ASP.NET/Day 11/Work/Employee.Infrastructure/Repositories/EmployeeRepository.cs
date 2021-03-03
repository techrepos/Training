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

        private readonly IEmployeeDataContext _dataContext;

        public EmployeeRepository(IEmployeeDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int AddEmployee(EmployeeEntity Employee)
        {
            return _dataContext.CreateEmployee(Employee);
        }

        public bool DeleteEmployee(int EmployeeId)
        {


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
            return new EmployeeEntity();
        }

        public bool SaveEmployee(EmployeeEntity Employee)
        {
           
            return false;
        }
    }
}
