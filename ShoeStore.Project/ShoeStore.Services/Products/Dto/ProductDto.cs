using Microsoft.AspNetCore.Http;
using ShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Products.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public Title Title { get; set; }
        public Genre Genre { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string Image { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
