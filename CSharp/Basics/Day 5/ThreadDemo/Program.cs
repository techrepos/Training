using System;
using System.Reflection;
using System.Threading;

namespace Basics
{
    class Program
    {
        bool isFinished;

        static readonly object locker = new object();
        static void Main(string[] args)
        {
            //a thread is an independent execution path 
            // and is able to run with other threads in parallel
            //its upto the OS' scheduler to allocate resources and processor time to run these

            //creates a new thread and executes the method WriteUsingNewThread
            //Thread t = new Thread(WriteUsingNewThread);          
            //t.Start();



            //Thread t1 = new Thread(WriteUsingNewThread);
            //t1.Start();

            // in the mean time the following code will be executed in the main thread
            //C# program starts with a single thread created by the CLR 
            //we can then create multiple threads from this main thread, 
            //for (int i = 0; i < 1000; i++) Console.WriteLine($"Parent Thread {i}");

            //clr maintains a separate memory stack for storing the variables for each thread
            //calls the method in a separate thread
            /*new Thread(()=>LocalVariableDemo("Child")).Start();
             LocalVariableDemo("Main ");*/

            //to share the data between the threads, attach it to the same instance

            /*Program objDemo = new Program();
            Thread t1 = new Thread(objDemo.SharedVariableDemo);
            t1.Start();
            Thread.Sleep(5000);
            objDemo.SharedVariableDemo();*/

            /*Program objDemo = new Program();
            new Thread(objDemo.ThreadSafetyDemo).Start();
            objDemo.ThreadSafetyDemo();*/

            //join demo
            //you can use the Join method to wait for another thread to finish 
            /* Thread threadObj = new Thread(WriteUsingNewThread);
             threadObj.Start();
             threadObj.Join();
             //Thread.Sleep(500); //to suspend the execution of the thread for a time specified in ms
             Console.WriteLine("Finished executing WriteUsingNewThread"); */

            //passing params
            // Thread th = new Thread(() => LocalVariableDemo("Anonymous"));
            //th.Start(); 
            //internally the Thread class ctor has two overloads , 
            //one with empty param and one accepts an object
            //Thread th1 = new Thread(LocalVariableDemoAsObject);
            //th1.Start("via  start menthod");

            //naming threads
            /*Thread.CurrentThread.Name = "Parent";
            Thread thChild = new Thread(WriteUsingNewThread);
            thChild.Name = "Child Thread";
            thChild.Start();
            Console.WriteLine($"Current Thread -> {(Thread.CurrentThread.IsBackground ? "Background" : "foreground")}");
            Console.WriteLine($"Child Thread -> {(thChild.IsBackground ? "Background" : "foreground")}");
            WriteUsingNewThread();*/

            //forground and background threads
            //by default, every thread you create are foreground threads
            //foreground threads will keep your appliaction alive, means the application will terminate only 
            //when all the foreground threads are finished
            //where as a background thread will abruptly terminate if the application completes execution
            /*Thread thread = new Thread(() => Console.ReadLine());
            if (args.Length > 0)
                thread.IsBackground = true;
            thread.Start(); */

            //try catch exceptions
            //master thread

            //TryCatchDemo();
            //child thread
           // new Thread(TryCatchDemo).Start();




        }
        static void WriteUsingNewThread()
        {
            for (int i = 1000; i > 1; i--) Console.WriteLine($"New thread {i}");
        }

        static void LocalVariableDemo(string name)
        {
            //local variable is declared, initialized and incremeted
            // a separate copy of the ctr variable is mainitained in a separated on each thread's memory stack
            for (int ctr = 0; ctr < 10; ctr++)
            {

                Console.WriteLine($"{name} -> {ctr}");

            }
        }

        static void LocalVariableDemoAsObject(object inputParam)
        {
            var name = inputParam as string;
            //local variable is declared, initialized and incremeted
            // a separate copy of the ctr variable is mainitained in a separated on each thread's memory stack
            for (int ctr = 0; ctr < 10; ctr++)
            {

                Console.WriteLine($"{name} -> {ctr}");

            }
        }
        void SharedVariableDemo()
        {
            //this is not an ideal way of doing things
            //two threads trying to access the same info almost same time can lead to provide inconsistent data
            if (!isFinished)
            {
                isFinished = true;
                Console.WriteLine("Finished executing the method");
            }
        }

        void ThreadSafetyDemo()
        {
            //obtain an exclusive lock and then manipulate data
            //when two threads tries to simulataneously access data, one will have access to data
            //and the other will wait until the one have the lock finishes
            //this is called thread safe code
            lock (locker)
            {
                if (!isFinished)
                {
                    isFinished = true;
                    Console.WriteLine("Finished executing the method");
                }
            }

        }

        static void TryCatchDemo()
        {
            //throw new NotImplementedException("Not Implemented");
            try
            {
                throw null;
            }
            catch (Exception)
            {

                Console.WriteLine("Exception Occured");
            }
        }




    }

    
}
