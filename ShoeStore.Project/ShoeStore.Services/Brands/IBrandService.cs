using ShoeStore.Services.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Brands
{
    public interface IBrandService
    {
        void Add(BrandDto brandDto);
        void Delete(int id);
        BrandDto Get(int id);
        List<BrandDto> GetAll();
        void Update(BrandDto brandDto);

    }
}
