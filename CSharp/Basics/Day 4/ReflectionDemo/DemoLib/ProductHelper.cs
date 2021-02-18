using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoLib
{
    public class ProductHelper
    {
        [Required]
        public Product product { get; set; }

        public ProductHelper()
        {
            product = new Product();
            product.Id = 1;
        }

        public ProductHelper(int id, string name, string desc, decimal price)
        {
           product = new Product { Id = id, Name = name, Description = desc, Price = price };

        }

        [Obsolete]
        public void DisplayProductInfo(Product product)
        {
            WriteMessage($"{nameof(Product.Id)} - {product.Id}");
            WriteMessage($"{nameof(Product.Name)} - {product.Name}");
            WriteMessage($"{nameof(Product.Description)} - {product.Description}");
            WriteMessage($"{nameof(Product.Price)} - {product.Price}");
        }
        private void WriteMessage(string Message)
        {
            Console.WriteLine(Message);
        }

        public void Showout(out int value)
        {
            value = 10;
        }
    }
}
