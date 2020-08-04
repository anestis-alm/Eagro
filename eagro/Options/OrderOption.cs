using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Options
{
    public class OrderOption
    {
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderCountry { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        
        public int CustomerId { get; set; }
        public int BasketId { get; set; }
    }
}
