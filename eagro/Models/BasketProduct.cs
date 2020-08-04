using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public decimal ProdQuantity { get; set; }
        public decimal ProdPrice { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
