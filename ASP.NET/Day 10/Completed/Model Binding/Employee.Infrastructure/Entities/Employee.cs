using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Infrastructure.Entities
{
    
    //[Bind("Id,FirstName,LastName,EmailAddress")]
    public class EmployeeEntity
    {
        public int Id { get; set; }
        [ModelBinder(Name ="first_name")]
        public string FirstName { get; set; }
        [ModelBinder(Name = "last_name")]
        public string LastName { get; set; }
        [BindRequired]
        public string EmailAddress { get; set; }
        public int Age { get; set; }

        [BindNever]
        public String HomeAddress { get; set; }
        public String Worklocation { get; set; }
    }
}
