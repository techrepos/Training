using Basics.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Utility
{
    class Operations : FileOperations,IOperations
    {
        protected int Id;
        protected string Name;
        public void AddData()
        {
            Console.WriteLine($"Employee created, ID -> {Id}, name -> {Name}");
        }

        public bool DeleteData()
        {
            Console.WriteLine($"Employee deleted, ID -> {Id}");
            return true;
        }

        public bool UpdateData()
        {
            Console.WriteLine($"Employee Updated, ID -> {Id}");
            return true;
        }

        public virtual string GetData()
        {
            return Name;
        }

    }
}
