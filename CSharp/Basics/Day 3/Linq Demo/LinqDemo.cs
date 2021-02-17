using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public double Price { get; set; }
    }
    public class ProductDemo
    {
        public Product product { get; set; }
        public void DisplayProduct()
        {
            Console.WriteLine($"{product.Name}, {product.Descrption}");
        }
        public void DisplayProduct(Product prod)
        {
            product = prod;
            DisplayProduct();
        }
    }
    public class LinqDemo
    {

        public List<Product> products { get; set; }

        public LinqDemo()
        {
            products = new List<Product>
            {
                new Product { ProductId=1, Name="Tea - Mint", Descrption="Brandy Cherry - Mcguinness", Price=12},
                new Product { ProductId=2, Name="Coffee - Ristretto Coffee Capsule", Descrption="Wine - White, Riesling, Henry Of", Price=25},
                new Product { ProductId=3, Name="Teriyaki Sauce", Descrption="Oil - Margarine", Price=36.65},
                new Product { ProductId=4, Name="Snapple - Mango Maddness", Descrption="Tandoori Curry Paste", Price=42.55},
                new Product { ProductId=5, Name="Broom - Angled", Descrption="Raspberries - Fresh", Price=50},
                new Product { ProductId=6, Name="Cheese - Boursin, Garlic / Herbs", Descrption="Wanton Wrap", Price=60},
                new Product { ProductId=7, Name="Cream - 10%", Descrption="Tomato - Peeled Italian Canned", Price=52},
                new Product { ProductId=8, Name="Flour - Strong", Descrption="Island Oasis - Pina Colada", Price=55},
                new Product { ProductId=9, Name="Bread - Roll, Canadian Dinner", Descrption="Longos - Lasagna Beef", Price=65},
                new Product { ProductId=10, Name="Daves Island Stinger", Descrption="Goulash Seasoning", Price=25},
                new Product { ProductId=11, Name="Piping - Bags Quizna", Descrption="Lettuce - Lambs Mash", Price=36},
                new Product { ProductId=12, Name="Beer - Tetleys", Descrption="Dome Lid Clear P92008h", Price=12},
                new Product { ProductId=13, Name="Beer - Bud", Descrption="Dome Lid Clear P92008h", Price=12},
                new Product { ProductId=13, Name="Beer - Fosters", Descrption="Dome Lid Clear P92008h", Price=12},
                new Product { ProductId=13, Name="Beer - Fosters", Descrption="Dome Lid Clear P92008h", Price=12}
            };
        }
        public void SimpleLinqDemo()
        {
            //query Syntax

            //three combination
            //initialization
            //condition
            //selection
            var list = from obj in products //init
                       select obj; //selection
            foreach (var item in list)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }
            
            var condtionalList = from obj in products //init
                       where obj.Price > 20 //condition, not mandatory
                       select obj; //selection
            foreach (var item in condtionalList)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }
           
            //method syntax
            var methodList = products.Where(obj => obj.Price > 20).ToList();
            foreach (var item in methodList)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }

            //mixed syntax


            var itemSum = (from obj in products //init
                           where obj.Price > 20 //condition, not mandatory
                           select obj.Price).Sum(); //selection
            Console.WriteLine($"Sum is {itemSum}");
        }

        public void IEnumDemo()
        {
            //IEnumerableis an interface available in System.Collections. namespace
            // has got a method called GetEnumerator which helps you to iterate through the collection
            IEnumerable<Product> condtionalList = products.Where(x => x.Name.StartsWith("C"));
            foreach (var item in condtionalList)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }

            //IQueryable is available in System.Linq
            // is a child class of IEnumerable, so we can store it in a variable of type  IQueryable
            //to return the collection one need to call the AsQueryable() method on the list
            IQueryable<Product> queryList = products.AsQueryable().Where(x => x.Name.StartsWith("C"));
            foreach (var item in queryList)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }
            // difference
            //both of them can hold collection of data that can perfrom data manipulation operations
            //IEnumerable executes the select statement on the server side, loads the data on to the memory and then applies the filters
            //mostly used with in memory data collection items like List, Array

            //IQueryable executes the select query with the applied filter on the server side and then retrieves the data
            // normally used with out of memory collections such as database 
        }

        public void SelectDemo()
        {
            var list = products.ToList(); // returns the item
            foreach (var item in list)
            {
                Console.WriteLine($"{nameof(item.ProductId)} : {item.ProductId}, {nameof(item.Name)} : {item.Name} , {nameof(item.Price)}: {item.Price}");
            }

            var filterdProp = products.Select(x=> x.ProductId).ToList(); // returns only one property
            foreach (var item in filterdProp)
            {
                Console.WriteLine($"ProductId : {item}");
            }

            var fewProp = products.Select(x => new Product { 
              Name =  x.Name,
              Descrption = x.Descrption
            }).ToList(); // returns only a subset of  properties
            foreach (var item in fewProp)
            {
                Console.WriteLine($"{nameof(item.Name)} : {item.Name},  {nameof(item.Descrption)} : {item.Descrption} ");
            }

            var anopProp = products.Select(x => new 
            {
                ProductName = x.Name,
                ProductDescrption = x.Descrption
            }).ToList(); // using anonymous data type
            foreach (var item in anopProp)
            {
                Console.WriteLine($"{nameof(item.ProductName)} : {item.ProductName},  {nameof(item.ProductDescrption)} : {item.ProductDescrption} ");
            };

        }

        public void OperationsDemo()
        {
            //distinct
            var distinctList = products.ToList()
                .Select(x => new { x.Name, x.ProductId})
                .Distinct();
            foreach (var item in distinctList)
                Console.WriteLine($"{item.ProductId} {item.Name}");

            //except
            var secList = new List<Product>()
            {
                new Product { ProductId=6, Name="Cheese - Boursin, Garlic / Herbs", Descrption="Wanton Wrap", Price=60},
                new Product { ProductId=7, Name="Cream - 10%", Descrption="Tomato - Peeled Italian Canned", Price=52},
                new Product { ProductId=8, Name="Flour - Normal", Descrption="Island  - Pina Colada", Price=56},
                new Product { ProductId=9, Name="Bread - Roll, Canadian Dinner", Descrption="Longos - Lasagna Beef", Price=65}
            };

            //retrieves only the items in the first list that are not there in the second one
            var subData = products.Select(x=>x.Name).Except(secList.Select(y=> y.Name)).ToList();
            
            foreach (var item in subData)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }
            Console.WriteLine("******************");
             //only the matching ones from the both lists
            var intData = products.Select(x => x.Name).Intersect(secList.Select(y => y.Name)).ToList();

            foreach (var item in intData)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //combines both the data sets in to one omitting the duplicate ones
            var unionData = products.Select(x => x.Name).Union(secList.Select(y => y.Name)).ToList();

            foreach (var item in unionData)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //retrieves first four elements from the list
            var takeDemo = products.Select(x => x.Name).Take(4).ToList();

            foreach (var item in takeDemo)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //take while, will retrieve the elements while the condition is met
            var takeWhileDemo = products.Select(x => new { x.Name, x.Price }).TakeWhile( z=> z.Price < 60).ToList();

            foreach (var item in takeWhileDemo)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //skips first 5 elements from the list
            var skipDemo = products.Select(x => x.Name).Skip(5).ToList();

            foreach (var item in skipDemo)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //generates a sequence of numbers
            var seqDemo = Enumerable.Range(10, 20);

            foreach (var item in seqDemo)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }

            Console.WriteLine("******************");
            //generates a sequence of repeated value
            var repDemo = Enumerable.Repeat("Hello World:", 10);

            foreach (var item in repDemo)
            {
                Console.WriteLine($" {nameof(item)} : {item}");
            }



        }
    }

}
