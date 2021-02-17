
using Basics.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Employee
{
    class EmployeeManagement :  Operations
    {
        public EmployeeManagement(int EmpId, String EmpName)
        {
            Id = EmpId;
            Name = EmpName;
        }
       public void CreateEmployee()
        {
            
            AddData();
            FileName = Name;
            CreateFile();
        }

        public override string GetData()
        {

            return $"Name is {base.GetData()}";
        }
    }
}
