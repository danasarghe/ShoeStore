using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Title Title { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public  Genre Genre { get; set; }
        public  Brand Brand { get; set; }
    }
}
