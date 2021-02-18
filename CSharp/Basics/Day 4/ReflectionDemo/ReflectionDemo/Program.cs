
using DemoLib;
using System;
using System.IO;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "amal";
            Console.WriteLine(name.GetType());

            Assembly assmeblyInfo = typeof(string).Assembly;
            Console.WriteLine(assmeblyInfo);
            var productHelper = new ProductHelper();

            //reflection demo
            //GetType can be used to get info about the under;ying type of an object


            //get information about the  assembly
            //here it will give you the metadata about corelib assembly
            // When you have an instance, you will use the GetType() method
            //to get the type metadata of a class, use typeof

            Type type = typeof(Product);
            Console.WriteLine($"Class name - {type.Name}");
            Console.WriteLine($"Assembly name - {type.Assembly}");




            Product prod = new Product();
            type = prod.GetType();
            Console.WriteLine($"Class name - {type.Name}");
            Console.WriteLine($"Assembly name - {type.Assembly}");

            //get all the properties inside the class
            //prod = new Product();
            //type = prod.GetType();
            PropertyInfo[] propInfo = type.GetProperties();
            foreach (PropertyInfo info in propInfo)
            {
                Console.WriteLine($"Property Name -> {info.Name}");
            }

            //getting info about constructor
            type = typeof(ProductHelper);
            ConstructorInfo[] ctorInfo = type.GetConstructors();
            foreach (ConstructorInfo info in ctorInfo)
            {
                Console.WriteLine($"Constructor -> {info}");
                foreach (var parameter in info.GetParameters())
                {
                    Console.Write("Name: " + parameter.Name + ", ");
                    Console.Write("Parameter Type: " + parameter.ParameterType.Name + ", ");
                    Console.Write("Position: " + parameter.Position + ", ");

                    Console.Write("IsOutput: " + parameter.IsOut + ", ");
                    Console.Write("IsOptional: " + parameter.IsOptional + ", ");

                    if (parameter.HasDefaultValue)
                    {
                        Console.Write("Default Value: " + parameter.DefaultValue);
                    }
                    Console.WriteLine();
                }
            }


            //get all methods
            MethodInfo[] methodInfo = type.GetMethods();
            //methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo info in methodInfo)
            {
                Console.WriteLine($"Methods -> {info}");
            }

            //get custom attributes
            foreach (MethodInfo info in methodInfo)
            {
                foreach (Attribute attribute in info.GetCustomAttributes(true))
                    Console.WriteLine($"Custom Attribute -> {attribute}");
            }



            //get executing assembly information
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Name -> {assembly.GetName().Name}, Version -> {assembly.GetName().Version}");
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (Type items in assemblyTypes)
                Console.WriteLine(items.Name);


            //get calling assembly information
            assembly = Assembly.GetCallingAssembly();
            Console.WriteLine($"Name -> {assembly.GetName().Name}, Version -> {assembly.GetName().Version}");
            assemblyTypes = assembly.GetTypes();
            foreach (Type items in assemblyTypes)
                Console.WriteLine(items.Name);

            //load assembly from disk
            assembly = Assembly.LoadFrom("./DLL/CSharpBasics.dll");
            Console.WriteLine($"Name -> {assembly.GetName().Name}, Version -> {assembly.GetName().Version}");
            assemblyTypes = assembly.GetTypes();
            foreach (Type items in assemblyTypes)
                Console.WriteLine(items.Name);

            //invoke constructor

            Type customType = assembly.GetType("CSharpBasics.LinqDemo");
            ConstructorInfo ctor = customType.GetConstructor(System.Type.EmptyTypes);
            object instance = ctor.Invoke(null);

            //invoke method
            // Get the method to call.
            MethodInfo customMethod = customType.GetMethod("SimpleLinqDemo");
            // Create an instance.
            object obj = Activator.CreateInstance(customType);
            // Execute the method.
            customMethod.Invoke(obj, null);




            //get  properties
            //invoke method
            customType = assembly.GetType("CSharpBasics.ProductDemo");

            PropertyInfo[] properties = customType.GetProperties();

            // Get the method to call.
            customMethod = customType.GetMethod("DisplayProduct", new[] { properties[0].PropertyType });


            var propObj = Activator.CreateInstance(properties[0].PropertyType);
            var Name = properties[0].PropertyType.GetProperty("Name");
            Name.SetValue(propObj, "AMAL");

            var Desc = properties[0].PropertyType.GetProperty("Descrption");
            Desc.SetValue(propObj, "Descrption");

            // Create an instance.
            obj = Activator.CreateInstance(customType);
            // Execute the method.
            customMethod.Invoke(obj, new[] { propObj });



            //new ProductHelper().DisplayProductInfo(new Product { Id= 101, Name = "Neon",Description= "Adidas neon shoes", Price= (decimal)29.2});

        }
    }
    class SampleClass { }
}

