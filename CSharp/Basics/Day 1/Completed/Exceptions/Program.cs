using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {

            ExceptionDemo ex = new ExceptionDemo();

            ex.SimpleExceptionHandling();

           Console.WriteLine( ex.ExceptionFilterDemo());

           Console.WriteLine( ex.CustomExceptionDemo());
        }




    }
}
