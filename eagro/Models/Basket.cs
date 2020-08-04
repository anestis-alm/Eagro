using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<BasketProduct> BasketProducts{ get; set; }     
    }
}
