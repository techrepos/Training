using System;

namespace Basics.Class
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }



        public String GetFullName() => FirstName + " " + LastName;
    }
}
