using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Entities
{
    public class EmployeeSearchParams : SearchParams
    {
        public int DeptId { get; set; }
        public string Query { get; set; }
    }
}
