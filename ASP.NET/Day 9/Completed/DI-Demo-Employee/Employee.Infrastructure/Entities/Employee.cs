using System;
using System.Collections.Generic;
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
    }
}
