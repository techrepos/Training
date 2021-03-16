using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Infrastructure.Entities
{
    public class EmployeePayments
    {
        public int Id { get; set; }

        public DateTime PaidDate { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeEntity Employee { get; set; }
    }
}
