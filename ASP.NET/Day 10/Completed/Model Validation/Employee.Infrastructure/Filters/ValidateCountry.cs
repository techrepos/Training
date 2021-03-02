using Employee.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Filters
{
    public class    ValidateCountry: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var empModel = validationContext.ObjectInstance as EmployeeEntity;
            if (!String.IsNullOrWhiteSpace(empModel.HomeAddress) && String.IsNullOrWhiteSpace(empModel.Country))
                return new ValidationResult("Country is required");
            else
               return ValidationResult.Success;
        }
    }
}
