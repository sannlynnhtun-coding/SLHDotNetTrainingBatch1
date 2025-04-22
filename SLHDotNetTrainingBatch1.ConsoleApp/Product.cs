using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.ConsoleApp
{
    internal class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

        public Product(int id, string code, string name, decimal price, int quantity, string category)
        {
            Id = id;
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }
    }
}
