using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data.Entities
{
   public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> OrderItems { get; set; }
  
    }
}
