using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Services.Brands;
using ShoeStore.Services.Brands.Dto;
using ShoeStore.Web.Models;

namespace ShoeStore.Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            var brandDto = brandService.GetAll();
            var model = brandDto.Select(b => new BrandsViewModel
            {
                Id = b.BrandId,
                Name = b.Name
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            
            var brand = brandService.Get(id);

            if (brand == null)
            {
                return View("NotFound");
            }

            var model = new BrandsViewModel
            {
                Id = brand.BrandId,
                Name = brand.Name
            };
            return View(model);

        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] BrandsViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var brandDto = new BrandDto()
            {
                BrandId = model.Id,
                Name = model.Name
            };

           brandService.Add(brandDto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var brand = brandService.Get(id);
            if(brand == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var brandViewModel = new BrandsViewModel
            {
                Id = brand.BrandId,
                Name = brand.Name
            };

            return View(brandViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] BrandsViewModel brandsViewModel)
        {
            var brand = brandService.Get(brandsViewModel.Id);
            if (brand == null)
            {
                return RedirectToAction(nameof(Index));
            }
            brand.Name = brandsViewModel.Name;
            brandService.Update(brand);

            return RedirectToAction("Index");
        }
    }
   
   
}