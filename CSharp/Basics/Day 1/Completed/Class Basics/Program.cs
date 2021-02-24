using Basics.Class;
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            emp.EmployeeId = 101;
            emp.FirstName = "Amal";
            emp.LastName = "Dev";

            Console.WriteLine(emp.GetFullName());

            Employee empNew = new Employee { EmployeeId = 222, FirstName = "Joe", LastName = "Doe" };
            Console.WriteLine(empNew.GetFullName());
        }

    }
}
