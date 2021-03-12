using System;

namespace Web_Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid cart_id { get; set; }
        public int Product_id { get; set; }

        public int Quantity { get; set; }
    }
}