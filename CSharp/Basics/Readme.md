## Day1 : C# Basics

### [Table of Contents](#table-of-contents)
1. [Structure](#structure)

2. [Methods](#methods)
    - [Consuming Methods](#consuming-methods)
    - [Methods with params](#methods-with-params)
    - [Pass params to method as reference](#pass-params-to-method-as-reference)
    - [Using `out` keyword to pass value to methods](#Using-out-keyword-to-pass-value-to-methods)
    - [Arbitary no of params in a method](#arbitary-no-of-params-in-a-method)
    - [Default values for parameters](#default-values-for-parameters)
    - [Named Arguments](#named-arguments)
    - [Expression Bodied Members](#expression-bodied-members)

3. [Class](#class)
    - [Instantiating class](#instantiating-class)
    - [Properties](#properties)
        - [Read Only Property](#read-only-property)
        - [Write-Only Property](#write-only-property)
        - [Read-Write Properties](#read-write-properties)
        - [Automatic Properties](#automatic-properties)
4. [Interface](#inteface)
5. [Inheritance](#inheritance)
6. [String Management](#string-management)
    - [Concatenation](#concatenation)
    - [Replace a string](#replace-a-string)
    - [Replace all occurances](#replace-all-occurances)
    - [Escape backslash](#escape-backslash)
    - [Verbatim String](#verbatim-string)

7. [String Interpolation](#string-interpolation)

8. [Exception Handling](#exception-handling)
    - [Custom Exceptions](#custom-exceptions)
    - [Exception filters](#exception-filters)


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

### Expression Bodied Members
- Introduced with C# 6.0 and enhanced in v7.0
- Is a new way of writing code to make it more readable and concise
- Can be applied to
    - Constructor
    - Destructor
    - Property getter and setter
    - Methods
- Can only be used if any of the above has only a single statement

**Syntax**
```html
member => expression;
```
Example
```csharp
private static int Add(int firstArg, int secondArg)
{
   return a + b;
}

// can be rewritten as

private static int Add(int firstArg, int secondArg) => a + b;


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

### Instantiating class

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

**Another way for creating an object**

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
### Properties

- A member of a class which is used to set and get the data from a data field of a class
- Types of properties
    - Read-only property
    - Write only property
    - Read Write property
    - Auto-implemented property

**Read Only Property**

- Only allows you to read values from it.
- Will get a compile time error if you try to assign value
- It will only have  get accessor
```csharp
//read only property
private string lastName;
public string LastName
{
    get { return lastName; }

}
```

**Write-Only Property**

- Only allows to store values
- Will only have set accessor
- Again a compile time error will be generated if you try to read data from it

```csharp
//write only property
private string address;
public string Address
{
    set { address = value; }

}
```

**Read-Write Properties**

- Allows you to store and retrieve data
- Will have both get and set accessor

```csharp
//read write properties
private string firstName;
public string FirstName
{
    get { return firstName; }
    set { firstName = value; }
}

//equivalent expression bodied syntax

```
**Automatic Properties**
- Compiler automatically creates the *private anonymous* backing fields

```csharp
//automatic properties
public string EmailAddress { get; set; }
```

**Set default value while creating the property**

```csharp
//initializes a empty string rather than a null value
public string EmailAddress { get; set; } = String.Empty;
```
## Interface
- `interface` keyword  is used to define an interface
- Covnention is to give a name starting with an `I`
- can contain declaration of methods, events, properties
- cannot have access specifiers for members, all are public by default
- An interface can inherit one or more interfaces
- When a class implements an interface it should provide definitions for all the members defined in the interface
Syntax
```html
interface <interface name>{

}
```
Example 
```csharp
//definition
interface IOperations
{
    void AddData(int Id, String Name);
    bool UpdateData(int Id);
    bool DeleteData(int Id);

}

//usage

class EmployeeManagement : IOperations
{
    public void AddData(int Id, String Name)
    {
        //code for inserting data
    }

    public bool UpdateData(int Id)
    {
        //code for updating data
    }

    public bool DeleteData(int Id)
    {
        //code for updating data
    }
}
```

## Inheritance

- A class can be derived from more than one class or interface  
- The child(derived class inherits the properties and members defined in the parent(base) class
- Also, child(derived) class can have its own method implementations
### Base & Derived Classes

Syntax
```html
<acess-specifier> class <base_class> {
   ...
}

class <derived_class> : <base_class> {
   ...
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

## Exception Handling 

- Are handled using try..catch..finally block
- try block should have at least a catch block or a finally block
- Can have multiple catch block
- If you have a finally block, then statements inside it will execute even if the catch block has a return statement

```csharp
FileStream file = null;
FileInfo fileInfo = null;

try
{
    fileInfo = new FileInfo("./file1.txt");

    file = fileInfo.Open(FileMode.Open);
    file.WriteByte(0xF);
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"File not found exception {e.Message}");
    return;
}
catch (UnauthorizedAccessException e)
{
    Console.WriteLine($"Unauthorized exception {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    file?.Close();
}
```
### Custom Exceptions 

- Can create custom exceptions by inheriting the `Exception` class


```csharp
public class InvalidResponseException : Exception
{

    
    public InvalidResponseException(int InputValue)
        : base(String.Format("Invalid response, your response code was {0}", InputValue.ToString()))
    {

    }
}


public string CustomExceptionDemo()
{
    
    try
    {
        var client = new HttpClient();
        var streamTask = client.GetStringAsync("http://www.google.in/");
        var responseText =  streamTask.Result;
        throw new InvalidResponseException(250);
        return responseText;
    }
    catch(InvalidResponseException e)
    {
        return e.Message;
    }
    catch (Exception e) 
    {

        return e.Message;
    }
}
}
```

### Exception filters 
- Introduced in C# 6
- Can specify condition along with the catch block, the statement inside it will be executed only if both conditions are met

```csharp
try
{
    var client = new HttpClient();
    var streamTask = client.GetStringAsync("http://www.google.com/test1");

    //var responseText =  streamTask.Result;
    return streamTask.Result;
}
catch (AggregateException e)  when (e.InnerExceptions.First().Message.Contains("404"))
{
    return "Not Found";
}
catch (HttpRequestException e ) when (e.Message.Contains("301"))
{
    return "Site Moved";
}
catch (HttpRequestException e) when (e.Message.Contains("404"))
{
    return "Page Not Found";
}
catch (HttpRequestException e)
{
    return e.Message;
}
```