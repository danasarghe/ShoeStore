using ShoeStore.Services.Products.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Products
{
    public interface IProductService
    {
        void Add(ProductDto productDto);
        void Delete(int id);
        ProductDto Get(int id);
        List<ProductDto> GetAll();
        void Update(ProductDto productDto);

    }
}
