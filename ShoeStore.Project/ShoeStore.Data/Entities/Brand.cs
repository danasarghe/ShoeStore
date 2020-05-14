using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
