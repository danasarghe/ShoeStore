using ShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Products.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Title Title { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
    }
}
