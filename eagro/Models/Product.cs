using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public bool Available { get; set; }
        public string ThemeImage { get; set; }

        public List<BasketProduct> BasketProducts { get; set; }
    }
}
