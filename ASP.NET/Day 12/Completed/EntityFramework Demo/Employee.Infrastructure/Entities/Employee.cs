
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Employee.Infrastructure.Entities
{
    
    public class EmployeeEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }

        public string Country { get; set; }

        public String HomeAddress { get; set; }
        public String Worklocation { get; set; }

        public int DepartmentId { get; set; }
        public Department Department{ get; set; }
    }
}
