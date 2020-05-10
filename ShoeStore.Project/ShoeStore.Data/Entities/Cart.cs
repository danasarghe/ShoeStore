using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShoeStore.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        [DisplayName("Quantity")]
        public int Count { get; set; }
        
        public System.DateTime DateCreated { get; set; }

        public Product Product { get; set; }
    }
}
