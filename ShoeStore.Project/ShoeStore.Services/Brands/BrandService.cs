using ShoeStore.Data;
using ShoeStore.Data.Entities;
using ShoeStore.Services.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IRepository<Brand> brandRepository, IUnitOfWork unitOfWork)
        {
            this.brandRepository = brandRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Add(BrandDto brandDto)
        {
            if (brandDto == null) throw new ArgumentNullException(nameof(brandDto));

            var brand = new Brand { Name = brandDto.Name };

            brandRepository.Add(brand);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var brand = brandRepository.GetById(id);
            if(brand==null) throw new Exception($"Brand with id :{id} was not found");

            brandRepository.Delete(brand);
            unitOfWork.Commit();
        }

        public BrandDto Get(int id)
        {
            //if (id < 1) throw new ArgumentException(nameof(id));

            var brand = brandRepository.GetById(id);
            if (brand == null) return null;

            var brandDto = new BrandDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            };

            return brandDto;
        }

        public List<BrandDto> GetAll()
        {
            var brands = brandRepository.GetAll();
            var brandDtos = new List<BrandDto>();

            foreach (var brand  in brands )
            {
                var brandDto = new BrandDto
                {
                    BrandId = brand.BrandId,
                    Name = brand.Name
                };
                brandDtos.Add(brandDto);

            }
            return brandDtos;
        }

        public void Update(BrandDto brandDto)
        {
            if (brandDto == null) throw new ArgumentNullException(nameof(brandDto));

            var brand = brandRepository.GetById(brandDto.BrandId);

            if (brand == null) throw new Exception($"Brand with Id = {brandDto.BrandId} was not found");

            brand.Name = brandDto.Name;

            brandRepository.Update(brand);
            unitOfWork.Commit();

        }
    }
}
