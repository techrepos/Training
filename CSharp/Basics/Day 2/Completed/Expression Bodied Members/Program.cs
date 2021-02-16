using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleLibrary objLib = new SampleLibrary();
            objLib.SayHello("Amal");
            Console.WriteLine(objLib.Sum(10, 20));

        }




    }

    class SampleLibrary
    {
        //normal syntax for a method with one line and no return statment
        /*
        public void SayHello(string message)
        {
            Console.WriteLine("Hello " + message);
        }
        */

        //optimized it with expression bodied syntax
        public void SayHello(string message) => Console.WriteLine("Hello " + message);

        //normal syntax for a method with a single return statement
        /* 
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
        */

        //optimized it with expression bodied syntax
        public int Sum(int num1, int num2) => num1 + num2;
    }
}
