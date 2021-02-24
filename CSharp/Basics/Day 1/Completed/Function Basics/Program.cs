using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //method with no params
            DisplayMessage();
            //method which expects a single param
            String messageString = "Welcome to the world of C#";
            DisplayMessage(messageString);

            //pass by ref example
            //initializes the string
            string refMessage = "Good Morning";
            Console.WriteLine("Before invoking method -> " + refMessage);
            //call the method and passes the value by ref
            DisplayMessageByRef(ref refMessage);
            Console.WriteLine("After invoking method -> " + refMessage);

            //out example
            DisplayMessageByOut(out String outMessage); // equivalent to String outMessage; DisplayMessageByOut(out outMessage);
            Console.WriteLine("After invoking method -> " + outMessage);

            //arbitary no of params
            Console.WriteLine("First method ");
            ChangeToLowerCase();
            Console.WriteLine("\nSecond method ");
            ChangeToLowerCase("Germany");
            Console.WriteLine("\nThird method ");
            ChangeToLowerCase("India", "USA", "UAE", "United Kingdom");

            //default params
            int a = 10;
            Console.WriteLine("Sum = " + Calculate(a) );

            //named arguments
            var retString = JoinString(SecondString: "  Amal", FirstString: "Hello");
            Console.WriteLine(retString);
        }


        private static void DisplayMessage()
        {
            Console.WriteLine("Hello World");
        }

        private static void DisplayMessage(String Message)
        {
            Console.WriteLine(Message);
           
        }

        private static void DisplayMessageByRef(ref String Message)
        {
            //appends a string to the incoming value
            Message += " World";
            Console.WriteLine("Inside DisplayMessageByRef -> " + Message);
            //appends another string to the modify the string variable again
            Message += "!!!";

        }

        private static void DisplayMessageByOut(out String Message)
        {
            //initializes param with value
            Message = " Good day";
            Console.WriteLine("Inside DisplayMessageByOut -> " + Message);
            //appends another string to the modify the string variable again
            Message += "!!!";

        }

        private static void ChangeToLowerCase(params string[] words)
        {
            foreach (var itm in words)
                Console.WriteLine(itm.ToLower());
        }

        private static int Calculate(int a, int b = 2)
        {
            return a + b;
        }

        private static String JoinString(String FirstString, String SecondString)
        {
            return FirstString + SecondString;
        }


    }
}
