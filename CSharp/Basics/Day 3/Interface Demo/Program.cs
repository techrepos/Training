using Basics.Employee;
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new EmployeeManagement(12,"test");
            
            obj.CreateEmployee();
         
            //Console.WriteLine(obj.GetData());

        }




    }

    
}
