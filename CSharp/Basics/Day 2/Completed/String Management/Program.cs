
using System;
using System.Text;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = String.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("hello");
            sb.Append(" ");

            Console.WriteLine(sb.ToString());

            //string management
            string msg = "Hello" + " " + "World"; //concatenation
            var joinedstring = String.Concat("asf", "asdas");

           

            Console.WriteLine(msg);
            Console.WriteLine(msg.Length); //gets length of the string output : 11

            string newMsg = msg.Replace("World", "India");
            Console.WriteLine(newMsg); //replaces string with another output: Hello India

            if (msg.Contains("l"))
                Console.WriteLine(msg.Replace("l", "L")); //replaces all occurances of a string if a match is foundX

            Console.WriteLine("Hello \"World\""); //escaping double quotes , output : Hello "World"

            Console.WriteLine("Yes \\ No"); //escaping back slash , output : Yes \ No

            Console.WriteLine(@"In a verbatim string \ everything is literal: \n & \t"); //is notified by the @ symbol, output : In a verbatim string \ everything is literal: \n & \t


            //String interpolation
            string msg1 = "hello";
            string msg2 = "World";
            Console.WriteLine(msg1 + " " + msg2); //old way
            
            Console.WriteLine($"The message is {msg1} - {msg2}");


            //Console.WriteLine($"{msg1} {msg2}"); //using interpolation

            Console.WriteLine($"Insert \"{msg1}\" between curly braces: {{message here}} {msg2}");
            //output -> Insert "hello" between curly braces: {message here} World

        }

    }
}
