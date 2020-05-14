using ShoeStore.Data;
using ShoeStore.Data.Entities;
using ShoeStore.Services.Brands;
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
        private readonly IBrandService brandService;

        public ProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork, IBrandService brandService)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.brandService = brandService;
        }
        public void Add(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            var product = new Product
            {
                Id = productDto.Id,
                Brand = productDto.Brand,
                Title = productDto.Title,
                Genre = productDto.Genre,
                Price = productDto.Price,
                Size = productDto.Size,
                Image = productDto.Image
            };
            productRepository.Add(product);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            //if (id < 0) throw new ArgumentException(nameof(id));

            var product = productRepository.GetById(id);
            if (product == null) throw new Exception($"Product with id :{id} was not found");

            productRepository.Delete(product);
            unitOfWork.Commit();

        }

        public ProductDto Get(int id)
        {
            //if (id < 0) throw new ArgumentException(nameof(id));

            var product = productRepository.GetById(id);
            if (product == null) return null;

            var productDto = new ProductDto
            {
                Id = product.Id,
                Image = product.Image,
                Brand = product.Brand,
                Title = product.Title,
                Genre = product.Genre,
                Price = product.Price,
                Size = product.Size
            };
            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return productRepository.Query().Select(p => new ProductDto
            {
                Id = p.Id,
                Image = p.Image,
                BrandName = p.Brand.Name,
                Title = p.Title,
                Genre = p.Genre,
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
            var product = productRepository.GetById(productDto.Id);
            if (product == null) throw new Exception($"Product with Id = {product.Id} was not found");

            product.Brand = productDto.Brand;
            product.Image = productDto.Image;
            product.Price = productDto.Price;
            product.Title = productDto.Title;
            product.Genre = productDto.Genre;
            product.Size = productDto.Size;

            productRepository.Update(product);
            unitOfWork.Commit();
        }
    }
}
