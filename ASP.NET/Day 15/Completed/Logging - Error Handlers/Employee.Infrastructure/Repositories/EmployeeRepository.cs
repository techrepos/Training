﻿using Employee.Infrastructure.Data;
using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeContext _dataContext{ get; set; }
        // public  ILogger<EmployeeRepository> _logger { get; set; }
         public  ILogger _logger { get; set; }
        public static List<EmployeeEntity> EmpDataStore { get; set; }

        //public EmployeeRepository(EmployeeContext dataContext, ILogger<EmployeeRepository> logger)
        public EmployeeRepository(EmployeeContext dataContext, ILoggerFactory logger)
        {
            _dataContext = dataContext;
            _logger = logger.CreateLogger("EmployeeCustomCategory");
            // _logger = logger;
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
            _logger.LogInformation($"Calling {nameof(EmployeeList)} method in {nameof(EmployeeRepository)}");
            return _dataContext.Employee.ToList();
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
    }
}
