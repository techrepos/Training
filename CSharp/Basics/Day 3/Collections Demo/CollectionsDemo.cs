using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Employee
    {
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
    }
    public class CollectionsDemo
    {
        //Array List
        public void ArrayListDemo()
        {
            //declaration 
            //is a non-generic type of collection
            //can hold any data type
            ArrayList arrList = new ArrayList();

            //Adding elements
            Console.WriteLine("Adding elements");
            arrList.Add(1);
            arrList.Add("Hello");
            arrList.Add(22.50);

            //adding multiple elements at once
            //ArrayList arrList = new ArrayList() { 1, "Hello", 22.50 };
            Console.WriteLine("Retrieving  elements");
            //accessing elements
            int firstItem = (int)arrList[0];
            string secondItem = (String)arrList[1];
            Double thirdItem = (Double)arrList[2];
            Console.WriteLine(firstItem);
            Console.WriteLine(secondItem);
            Console.WriteLine(thirdItem);
            //or
            //float thirdItem = (Double)arrList[2];

            //iterating through the list via foreach
            foreach (var item in arrList)
            {
                Console.WriteLine(item);
            }

            //iterating through for loop
            for (int i = 0; i < arrList.Count; i++)
            {
                Console.WriteLine(arrList[i]);
            }

        }
        public void SortedListDemo()
        {
            //sorted list stores as key value pairs
            //in the ascending order of key
            //key can be of any data type, but type should be 
            //same for all the elements
            //SortedList stList = new SortedList();
            //stList.Add("2", "Two");
            //stList.Add("5", "Five");
            //stList.Add("1", "One");
            //stList.Add("9", "Nine");

            //another way of doing it 
            SortedList stList = new SortedList()
            {
                {"2", "Two" },
                {"5", "Five" },
                {"1", "One" },
                {"9", "Nine" }
            };


            //accessing via for loop
            //for (int i = 0; i < stList.Count; i++)
            //{
            //    Console.WriteLine("key: {0}, value: {1}",
            //        stList.GetKey(i), stList.GetByIndex(i));
            //}

            //sorted list can be accessed via key 

            string valueByKey = (string)stList["9"];
            Console.WriteLine(valueByKey);


            //remove an element
            stList.Remove("1"); ///by key
            stList.RemoveAt(2); //by position

            //accessing via for loop
            for (int i = 0; i < stList.Count; i++)
            {
                Console.WriteLine("key: {0}, value: {1}",
                    stList.GetKey(i), stList.GetByIndex(i));
            }
        }

        #region Generics demo
        public void GenericListDemo()
        {
            //ArrayList , Sorted list can store any type of data
            //but while retreving items, you need to cast it inot appropriate type

            //can get rid of this issue by using generic collections
            //using System.Collections.Generic namespace
            //examples include List<T>, Dictionary<TKye,TValue>

            //List<T>

            List<int> intList = new List<int>();
            intList.Add(100);
            intList.Add(1000);
            intList.Add(25000);
            intList.Add(2645);

            Console.WriteLine("Integer collection");
            foreach (var item in intList)
                Console.WriteLine(item);

            List<String> strList = new List<String>();
            strList.Add("cat");
            strList.Add("mouse");
            strList.Add("lion");
            strList.Add("deer");

            Console.WriteLine("String  collection");



            foreach (var item in strList)
                Console.WriteLine(item);

            List<string> list2 = new List<string> { "parrot", "snake" };

            strList.AddRange(list2);

            Console.WriteLine("Appending items to the   collection");
            foreach (var item in strList)
                Console.WriteLine(item);

            //inserting items
            intList.Insert(2, 90);

            foreach (var item in intList)
                Console.WriteLine(item);

            intList.Remove(3);
            intList.RemoveAt(2);

            foreach (var item in intList)
                Console.WriteLine(item);
        }

        public void CustomListDemo()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee{ FirstName = "Amal" , LastName ="Dev", Designation="Employee"},
                new Employee { FirstName = "Tony" , LastName ="GM", Designation="Manager"},
                new Employee { FirstName = "John" , LastName ="Doe", Designation="Employee"},
                new Employee { FirstName = "Diego" , LastName ="Cruz", Designation="Employee"}
            };

            //iterating through for each
            foreach (var item in emp)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            //selecting elements through linq
            var empList = from employee in emp
                          where employee.Designation.Equals("Employee")
                          orderby employee.LastName
                          select employee;

            
            Console.WriteLine("Filtering employees using linq");
            foreach (var item in empList)
            {
                Console.WriteLine(item.LastName + " " + item.FirstName);
            }

            //selecting elements through lambda expression
            var empLambdaList = emp.Where(x => x.Designation.Equals("Employee"))
                                .OrderBy(x => x.LastName).ToList();
            
            Console.WriteLine("Filtering employees using lambda");
            empLambdaList.ForEach(x => { Console.WriteLine(x.LastName + " " + x.FirstName); });
        }
        #endregion


        public void GenericDictionaryDemo()
        {
            //is a collection of key value pairs
            Dictionary<int, string> dictObj = new Dictionary<int, string>();

            dictObj.Add(1, "One");
            dictObj.Add(10, "Ten");
            dictObj.Add(2, "Two");
            dictObj.Add(3, "Three");



            //access individual item 
            Console.WriteLine(dictObj[1]);
            Console.WriteLine(dictObj[2]);

            //REVISIT implement more functionalities

            //accessing via loop
            foreach (KeyValuePair<int, string> item in dictObj)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);

                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            //Try TryGetValue

            string result;

            if (dictObj.TryGetValue(10, out result))
            {
                Console.WriteLine(result);
            }
            else
            {

                Console.WriteLine("Could not find the specified key.");
            }

            //checking for elements
            dictObj.ContainsKey(1); //find by key
            dictObj.Contains(new KeyValuePair<int, string>(1, "One")); //finds by item

            //removing elements
            dictObj.Remove(2);



        }

       
    }
}
