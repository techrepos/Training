## Day1 : C# Basics

## Structure
`using` keyword is used to import the namespaces into the program
A C# class will reside inside a namespace
Entry point is the `main` method

```csharp
using System;
namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    
```

**Output**
```bash
Hello World!
```
## Methods

### Consuming methods
Create a new private method in the `Program` class shown above

```csharp
private static void DisplayMessage(String Message)
{
    Console.WriteLine(Message);
}
```

Modify the main method to invoke the newly created method

```csharp
static void Main(string[] args)
{
    DisplayMessage("Welcome to the world of C#");
}
```

Complete code

```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMessage();
        }

        private static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the world of C#");
        }

    }
}

```

**Output**

```bash
Welcome to the world of C#
```

### Methods with params

Parameters can be passed by value or by reference
Default is **By Value**
Create a new private method in the `Program` class shown above

```csharp
 private static void DisplayMessage(String Message)
{
    Console.WriteLine(Message);
}
```

Modify the main method to invoke the newly created method

```csharp
static void Main(string[] args)
{
    String message = "Welcome to the world of C#";
    DisplayMessage(message);
}
```

Complete code

```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMessage("Welcome to the world of C#");
        }

        private static void DisplayMessage(String Message)
        {
            Console.WriteLine(Message);
        }

    }
}

```

**Output**

```bash
Welcome to the world of C#
```
### Pass params to method as reference
`ref` keyword is used to pass by reference

Create a new method inside the `Program` class which accepts a string parameter with `ref` keyword

```csharp
 private static void DisplayMessageByRef(ref String Message)
{
    //appends a string to the incoming value
    Message += " World";
    Console.WriteLine("Inside DisplayMessageByRef -> " + Message);
    //appends another string to the modify the string variable again
    Message += "!!!";

}
```

Modify the `Main` method to call this newly created method

```csharp
//initializes the string
string refMessage = "Good Morning";
Console.WriteLine("Before invoking method -> " + refMessage);
//call the method and passes the value by ref
DisplayMessageByRef(ref refMessage);
Console.WriteLine("After invoking method -> " + refMessage);
```

Complete code

```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
             //initializes the string
            string refMessage = "Good Morning";
            Console.WriteLine("Before invoking method -> " + refMessage);
            //call the method and passes the value by ref
            DisplayMessageByRef(ref refMessage);
            Console.WriteLine("After invoking method -> " + refMessage);
        }
       
        private static void DisplayMessageByRef(ref String Message)
        {
            //appends a string to the incoming value
            Message += " World";
            Console.WriteLine("Inside DisplayMessageByRef -> " + Message);
            //appends another string to the modify the string variable again
            Message += "!!!";

        }

    }
}

```
**Output**

```bash
Before invoking method -> Good Morning
Inside DisplayMessageByRef -> Good Morning World
After invoking method -> Good Morning World!!!
```

### Using `out` keyword to pass value to methods

Add a new method which accepts param as an `out` variable
```csharp
private static void DisplayMessageByOut(out String Message)
{
    //initializes param with value
    Message = " Good day";
    Console.WriteLine("Inside DisplayMessageByOut -> " + Message);
    //appends another string to the modify the string variable again
    Message += "!!!";

}
```

Modify `main` method to invoke the newly created function
```csharp
//out example
DisplayMessageByOut(out String outMessage); // equivalent to String outMessage; DisplayMessageByOut(out outMessage);
Console.WriteLine("After invoking method -> " + outMessage);
```

Complete code

```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //out example
            DisplayMessageByOut(out String outMessage); // equivalent to String outMessage; DisplayMessageByOut(out outMessage);
            Console.WriteLine("After invoking method -> " + outMessage);
        }

        private static void DisplayMessageByOut(out String Message)
        {
            //initializes param with value
            Message = " Good day";
            Console.WriteLine("Inside DisplayMessageByOut -> " + Message);
            //appends another string to the modify the string variable again
            Message += "!!!";

        }

    }
}

```

**Output**
```bash
Inside DisplayMessageByOut ->  Good day
After invoking method ->  Good day!!!
```

## Arbitary no of params in a method

- `param` keyword is used to specify arbitary no of values for a parameter
- Only one parameter is allowed to use the `param` keyword
- Functions with param keyword can accept normal parameters too
- 
```csharp
private static void ChangeToLowerCase(params string[] words)
{
    foreach (var itm in words)
        Console.WriteLine(itm.ToLower());
}
```

```csharp
Console.WriteLine("First method ");
ChangeToLowerCase();
Console.WriteLine("\nSecond method ");
ChangeToLowerCase("Germany");
Console.WriteLine("\nThird method ");
ChangeToLowerCase("India", "USA", "UAE", "United Kingdom");

```

Complete code
```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //arbitary no of params
            Console.WriteLine("First method ");
            ChangeToLowerCase();
            Console.WriteLine("\nSecond method ");
            ChangeToLowerCase("Germany");
            Console.WriteLine("\nThird method ");
            ChangeToLowerCase("India", "USA", "UAE", "United Kingdom");

        }

        private static void ChangeToLowerCase(params string[] words)
        {
            foreach (var itm in words)
                Console.WriteLine(itm.ToLower());
        }

    }
}

```

**Output**
```csharp
First method

Second method
germany

Third method
india
usa
uae
united kingdom
```

## Default values for parameters

Adds a new method specifies a default value for the second param
```csharp
 private static int Calculate(int a, int b = 2)
{
    return a + b;
}
```

Modify the main method to invoke this method

```csharp
//default params
int a = 10;
Console.WriteLine("Sum = " + Calculate(a) );

```

Complete code

```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //default params
            int a = 10;
            Console.WriteLine("Sum = " + Calculate(a) );


        }
     
        private static int Calculate(int a, int b = 2)
        {
            return a + b;
        }


    }
}

```

**Output**
```bash
Sum = 12
```

## Named Arguments

- Allows you to specify the arguments in any order while invoking the function
- Need to specify the name of the argument along with the value
- It can be in any order

Adds a new method which accepts string params and returns a concactnated string
```csharp
private static String JoinString(String FirstString, String SecondString)
{
    return FirstString + SecondString;
}
```

Modify the `Main` method to invoke the method

```csharp
//named arguments
var retString = JoinString(SecondString: "Amal", FirstString: "Hello");
Console.WriteLine(retString);
```

Complete code
```csharp
using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //named arguments
            var retString = JoinString(SecondString: "Amal", FirstString: "Hello");
            Console.WriteLine(retString);
        }

        private static String JoinString(String FirstString, String SecondString)
        {
            return FirstString + SecondString;
        }


    }
}

```
**Output**
```bash
Hello Amal
```
## Class

Create a new file for creating an `Employee` class. Save it as `Employee.cs`

Following snippet will create a class with properties and a method which returns the full name of the employee

Syntax
```
<access specifier> class <class name> {
    //properties
    ....
    //methods
}
```
Usage
```csharp
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public String GetFullName() => FirstName + LastName;
}
```

Instantiating class

Now in the main method, use the following snippet to create an object of the `Employee` class

```csharp
static void Main(string[] args)
{
    Employee emp = new Employee();

    emp.EmployeeId = 101;
    emp.FirstName = "Amal";
    emp.LastName = "Dev";

    Console.WriteLine(emp.GetFullName());
}
```

Output

```bash
Amal Dev
```

Another way for creating an object

```csharp
Employee empNew = new Employee { EmployeeId = 222, FirstName = "Joe", LastName = "Doe" };

Console.WriteLine(empNew.GetFullName());
```

Let's create a folder for all the classes and move the class created above to it. Also create a new namespaces for all the classes in that folder. Our class from the previous example will be like

```csharp
using System;

namespace Basics.Class
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }



        public String GetFullName() => FirstName + " " + LastName;
    }
}

```

Now, to use this class in our `Main` method, we will need to import it first. So our `Program` class will be 

```csharp
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

```

## String Management

### Concatenation

```csharp
string msg = "Hello" + " " + "World"; //concatenation
Console.WriteLine(msg);
Console.WriteLine(msg.Length); //gets length of the string output : 11
```
**Output**
```bash
Hello World
11
```

### Replace a string

```csharp
string msg = "Hello" + " " + "World";
string newMsg = msg.Replace("World", "India");
Console.WriteLine(newMsg); //replaces string with another output: Hello India
```
**Output**
```bash
Hello India
```


### Replace all occurances

```csharp
string msg = "Hello" + " " + "World";

if (msg.Contains("l"))
    Console.WriteLine(msg.Replace("l", "L")); //replaces all occurances of a string if a match is found

```
**Output**
```bash
HeLLo WorLd
```
### Escape  double quotes

```csharp
Console.WriteLine("Hello \"World\""); //escaping double quotes , output : Hello "World"
```
**Output**
```bash
Hello "World"
```
### Escape  backslash

```csharp
Console.WriteLine("Yes \\ No"); //escaping back slash , output : Yes \ No
```
**Output**
```bash
Yes \ No
```

### Verbatim String

```csharp
Console.WriteLine(@"In a verbatim string \ everything is literal: \n & \t"); //is notified by the @ symbol, output : In a verbatim string \ everything is literal: \n & \t

```
**Output**
```bash
In a verbatim string \ everything is literal: \n & \t
```

## String Interpolation

```csharp
string msg1 = "hello";
string msg2 = "World";
Console.WriteLine(msg1 + " " + msg2); //old way
Console.WriteLine($"{msg1} {msg2}"); //using interpolation

Console.WriteLine($"Insert \"{msg1}\" between curly braces: {{message here}} {msg2}");
//output -> Insert "hello" between curly braces: {message here} World

```

**Output**
```bash
hello World
hello World
Insert "hello" between curly braces: {message here} World

```