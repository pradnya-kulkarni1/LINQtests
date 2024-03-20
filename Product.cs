using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtests
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int QtyInStock { get; set; }
        public Product(int id, string name, string category, string Color, decimal price, int QtyInStock)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Color = Color;
            this.Price = price;
            this.QtyInStock = QtyInStock;
        }


    }
}
