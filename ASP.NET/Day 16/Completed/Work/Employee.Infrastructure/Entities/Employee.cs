
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Employee.Infrastructure.Entities
{
    
    
    public class EmployeeEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }



        public string PrimaryEmailAddress { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public String HomeAddress { get; set; }
        public String Worklocation { get; set; }
        
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
