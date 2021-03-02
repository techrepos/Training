using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public static List<EmployeeEntity> EmpDataStore { get; set; }


        public int AddEmployee(EmployeeEntity Employee)
        {
            if (EmpDataStore is null)
                EmpDataStore = new List<EmployeeEntity>();
            Employee.Id = EmpDataStore.Count > 0 ? EmpDataStore.Max(x => x.Id) + 1 : 1;
            EmpDataStore.Add(Employee);
            return Employee.Id;
        }

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
            return EmpDataStore??new List<EmployeeEntity>();
        }

        public EmployeeEntity GetEmployeeDetails(int Id)
        {
            return EmpDataStore.Where(x => x.Id.Equals(Id))
                                 .FirstOrDefault();
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
