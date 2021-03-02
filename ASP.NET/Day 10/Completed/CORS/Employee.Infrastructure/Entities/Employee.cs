using Employee.API.Filters;
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

        [Display(Name = "First Name")]
        [MaxLength(10, ErrorMessage ="Maximum length allowed is 10 characters")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [MaxLength(10)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Please provide a valid email addresss")]
        public string EmailAddress { get; set; }
        [Range(18, 75, ErrorMessage ="Age should be greater than 18 and less than 75")]
        public int Age { get; set; }

        [ValidateCountry(ErrorMessage = "Country will be required if Home Address is provided")]
        public string Country { get; set; }

        public String HomeAddress { get; set; }
        public String Worklocation { get; set; }
    }
}
