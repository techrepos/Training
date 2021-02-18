using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Basics
{
    class FileDemos
    {
        public static void StreamDemo()
        {
            // creates the file at the specified location
            StreamWriter sw = new StreamWriter("sample.txt");

            
            Console.WriteLine("enter input to write to the file");

            // To read the input from the user 
            string str = Console.ReadLine();

            // To write a line in buffer 
            sw.WriteLine(str);

            // To write in output stream 
            sw.Flush();

            // To close the stream 
            sw.Close();

            //read the contents from the file

            StreamReader sr = new StreamReader("sample1.txt");

            Console.WriteLine("Content of the File");

            // This is use to specify from where  
            // to start reading input stream 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            // To read line from input stream 
            string lines = sr.ReadLine();

            //// To read the whole file line by line 
            while (lines != null)
            {
                Console.WriteLine(lines);
                lines = sr.ReadLine();
            }

            //to read the whole file in one go
            string fullcontent = sr.ReadToEnd();
            Console.WriteLine(fullcontent);
            // to close the stream 

            sr.Close();

            //read file by line
            /*int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(@"sample1.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);*/
            // Suspend the screen.  

        }
        public static void FileDemo()
        {
            Console.WriteLine("Writing info to file as bytes");

            FileStream file = new FileStream("sample.txt", FileMode.OpenOrCreate,
            FileAccess.ReadWrite);
            for (int i = 1; i <= 20; i++)
            {
                file.WriteByte((byte)i);
            }
            file.Position = 0;
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine(file.ReadByte() + " ");
            }
            file.Close();


            
        }
        public static void XMLDemo()
        {
            //retrive details
            Console.WriteLine("Reading xml from a file and deserializing it");
            //loading the document into a object in memory from the file
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("SampleData.xml");

            string xmlString = xmlDocument.OuterXml;
            // reader object to read string from the stream 
            StringReader read = new StringReader(xmlString);
            XmlSerializer serialiser = new XmlSerializer(typeof(Product));
            
            //specialized class for reading xml from streams
            XmlReader reader = new XmlTextReader(read);
            
            Product p = (Product)serialiser.Deserialize(reader);
            Console.WriteLine($"{p.Name}, {p.Product_ID}, {p.Price}");
            reader.Close();
            read.Close();

            //write to file
            Console.WriteLine("Serializing XML and writing to a file");
            Product product = new Product
            {
                Product_ID = 7615,
                SKU = "HEH-2245",
                Name = "Simply Sweet Blouse",
                Product_URL = "https://www.domain.com/product/heh-2245",
                Price = 42,
                Retail_Price = 59.95
            };
            Console.WriteLine($"{product.Name}, {product.Product_ID}, {product.Price}");
            
            //create an empty xml doc
            XmlDocument xmlDoc = new XmlDocument();
            //creates a serializer for converting the info in the collection
            XmlSerializer serializer = new XmlSerializer(product.GetType());

            //reads the collection from the memory
            MemoryStream stream = new MemoryStream();
            
            //serializes the object and writes to the specified stream
            serializer.Serialize(stream, product);
            
            //resets to pointer to the first position
            stream.Position = 0;

            //reads the xml object from the stream and saves it as an xml file
            xmlDocument.Load(stream);
            xmlDocument.Save("Product.xml");
            stream.Close();

        }
        

        public static void FileManagementDemo()
        {
            //file exists or not

            Console.WriteLine("To Verify a file exists or not");
            if (File.Exists("sample.txt"))
            {
                Console.WriteLine("File exist");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }


            //to list all files in directory

            Console.WriteLine("List all the files inside a directory");
            string[] files = Directory.GetFiles(".");
            foreach (String item in files)
            {
                Console.WriteLine(item);
            }

            //to list all sub directories

            Console.WriteLine("List all the subdirectories only");
            string[] dirs = Directory.GetDirectories(".");
            foreach (String item in dirs)
            {
                Console.WriteLine(item);
            }

            //create a new directory

            Console.WriteLine("Creating a directory");

            Directory.CreateDirectory("SampleDir//ChildDir");

            //create a file

            Console.WriteLine("Creating a file inside the directory");
            if (!File.Exists("SampleDir//File1.txt"))
                using (File.Create(Path.Combine("SampleDir", "File1.txt"))) ;

            Console.ReadKey();
            //copy a file ,set to true to overwrite the file if it exists

            Console.WriteLine("Copying files");
            File.Copy("SampleDir//File1.txt", "SampleDir//File2.txt", true);

            //move a file

            Console.WriteLine("Moving file with overwrite");
            File.Move("SampleDir//File2.txt", "File.txt", true);

            //delete a file

            Console.WriteLine("Deleting a file");
            File.Delete("File.txt");
        }
        public static void JsonDemo()
        {

            Console.WriteLine("Reading json from a file and deserializing it");
            var jsonString = File.ReadAllText("Product.json");
            var product = JsonSerializer.Deserialize<Product>(jsonString);
            Console.WriteLine($"{product.Name}, {product.Product_ID}, {product.Price}");


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            product = JsonSerializer.Deserialize<Product>(jsonString, options);
            Console.WriteLine($"{product.Name}, {product.Product_ID}, {product.Price}");

            Console.WriteLine("Serializing JSON ");
            Product newProduct = new Product
            {
                Product_ID = 7615,
                SKU = "HEH-2245",
                Name = "Simply Sweet Blouse",
                Product_URL = "https://www.domain.com/product/heh-2245",
                Price = 42,
                Retail_Price = 59.95
            };

            var modelJson = JsonSerializer.Serialize(newProduct, options);
            Console.WriteLine(modelJson);

            Console.WriteLine("Reading json array from a file and deserializing it");
            var productsString = File.ReadAllText("Products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsString);
            foreach (var prod in products)
                Console.WriteLine($"{prod.Name}, {prod.Product_ID}, {prod.Price}");

            Console.WriteLine("Serializing a json array");
            var prodList = new List<Product>{
                new Product
                {
                    Product_ID = 7615,
                    SKU = "HEH-2245",
                    Name = "Simply Sweet Blouse",
                    Product_URL = "https://www.domain.com/product/heh-2245",
                    Price = 42,
                    Retail_Price = 59.95
                },
                new Product
                {
                    Product_ID = 8100,
                    SKU = "WKS-6016",
                    Name = "Uptown Girl Blouse",
                    Product_URL = "https://www.domain.com/product/wks-6016",
                    Price = 58,
                    Retail_Price = 89.95
                }
            };

            var productsJson = JsonSerializer.Serialize(prodList);
            Console.WriteLine(modelJson);
        }

        //private static void DataTableDemo()
        //{
        //    Console.WriteLine("Creating a datatable and storing information");
        //    DataTable tbl = new DataTable();
        //    //creating schema
        //    tbl.Columns.Add("Product_ID", typeof(int));
        //    tbl.Columns.Add("SKU", typeof(string));
        //    tbl.Columns.Add("Name", typeof(string));
        //    tbl.Columns.Add("Product_URL", typeof(string));
        //    tbl.Columns.Add("Price", typeof(decimal));
        //    tbl.Columns.Add("Retail_Price", typeof(decimal));

        //    //storing data
        //    tbl.Rows.Add(7615, "HEH-2245", "Simply Sweet Blouse", "https://www.domain.com/product/heh-2245", 42.0, 59.95);
        //    tbl.Rows.Add(8100, "WKS-6016", "Uptown Girl Blouse", "https://www.domain.com/product/wks-6016", 58.0, 89.95);

        //    //retrieving data
        //    foreach (DataRow row in tbl.Rows)
        //    {

        //        Console.WriteLine(row.Field<int>("Product_ID"));
        //        Console.WriteLine(row.Field<string>("SKU"));
        //        Console.WriteLine(row.Field<string>("Name"));
        //        Console.WriteLine(row.Field<string>("Product_URL"));
        //        Console.WriteLine(row.Field<decimal>("Price"));
        //        Console.WriteLine("*********************");

        //    }

        //    //retrieving data using linq methods
        //    var result = tbl
        //        .AsEnumerable()
        //        .ToList();
        //    //.Where(row => row.Field<int>("RowNo") == 1)
        //    result.ForEach(x => Console.WriteLine($"{x.Field<int>("Product_ID")}, {x.Field<string>("Name")}"));
        //}
    }


}
public class Product
{
    public int Product_ID { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Product_URL { get; set; }
    public double Price { get; set; }
    public double Retail_Price { get; set; }
}

