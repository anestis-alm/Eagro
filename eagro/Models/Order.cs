using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderCountry { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderShipped { get; set; }
        public string OrderTrackingNumber{ get; set; }
        public decimal OrderCost{ get; set; }

        public Customer Customer { get; set; }
        public Basket Basket { get; set; }
    }
}
