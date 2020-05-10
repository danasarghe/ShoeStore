using ShoeStore.Data;
using ShoeStore.Data.Entities;
using ShoeStore.Services.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Add(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            var product = new Product
            {
                Id = productDto.Id,
                BrandId = productDto.BrandId,
                Title = productDto.Title,
                Price = productDto.Price,
                Size = productDto.Size
            };
            productRepository.Add(product);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            if (id < 0) throw new ArgumentException(nameof(id));

            var product = productRepository.Get(id);
            if (product == null) throw new Exception($"Product with id :{id} was not found");

            productRepository.Delete(product);
            unitOfWork.Commit();

        }

        public ProductDto Get(int id)
        {
            if (id < 0) throw new ArgumentException(nameof(id));

            var product = productRepository.Get(id);
            if (product == null) return null;

            var productDto = new ProductDto
            {
                Id = product.Id,
                BrandId = product.BrandId,
                Title = product.Title,
                Price = product.Price,
                Size = product.Size
            };
            return productDto;
        }

        public List<ProductDto> GetAll()
        {
            return productRepository.Query().Select(p => new ProductDto
            {
                Id = p.Id,
                BrandId = p.BrandId,
                Title = p.Title,
                Price = p.Price,
                Size = p.Size
            }).ToList();

            //var products = productRepository.GetAll();
            //var productDtos = new List<ProductDto>();
            //foreach (var product in products)
            //{
            //    var productDto = new ProductDto
            //    {
            //        Id = product.Id,
            //        BrandId = product.BrandId,
            //        Title = product.Title,
            //        Price = product.Price,
            //        Size = product.Size
            //    };
            //    productDtos.Add(productDto);
            //}
            //return productDtos;
        }

        public void Update(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));
            var product = productRepository.Get(productDto.Id);
            if (product == null) throw new Exception($"Product with Id = {product.Id} was not found");

            product.BrandId = productDto.BrandId;
            product.Price = productDto.Price;
            product.Title = productDto.Title;
            product.Size = productDto.Size;

            productRepository.Update(product);
            unitOfWork.Commit();
        }
    }
}
