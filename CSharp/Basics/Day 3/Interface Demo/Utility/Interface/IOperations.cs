using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Utility.Interface
{
    interface IOperations
    {
        void AddData();
        bool UpdateData();
        bool DeleteData();

        string GetData();
    }
}
