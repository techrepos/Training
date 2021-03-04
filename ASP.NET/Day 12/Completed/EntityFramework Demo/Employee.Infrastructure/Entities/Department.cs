
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Employee.Infrastructure.Entities
{
    
    public class Department 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeEntity> Employees{ get; set; }

    }
}
