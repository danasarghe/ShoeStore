using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Services.Brands;
using ShoeStore.Services.Products;
using ShoeStore.Services.Products.Dto;
using ShoeStore.Web.Models;

namespace ShoeStore.Web.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShoesController(IProductService productService, IBrandService brandService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            var productDtos = _productService.GetAll();
            var brandsDtos = _brandService.GetAll();

            if (productDtos == null)
            {
                return View("NotFound");
            }
            var model = productDtos.Select(p => new ShoesViewModel
            {
                Id = p.Id,
                Image = p.Image,
                BrandName = p.BrandName,
                Title = p.Title,
                Genre = p.Genre,
                Price = p.Price,
                Size = p.Size,

            });
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var productDto = _productService.Get(id);

            if (productDto == null)
            {
                return View("NotFound");
            }
            var model = new ShoesViewModel
            {
                Id = productDto.Id,
                Image = productDto.Image,
                BrandName = productDto.BrandName,
                Title = productDto.Title,
                Genre = productDto.Genre,
                Price = productDto.Price,
                Size = productDto.Size
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Test = _brandService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ShoesViewModel model)
        {

            string uniqueFileName = UploadedFile(model);

            var productDto = new ProductDto
            {

                Id = model.Id,
                BrandName = model.BrandName,
                Title = model.Title,
                Genre = model.Genre,
                Size = model.Size,
                Price = model.Price,
                Image = uniqueFileName
            };
                _productService.Add(productDto);

                return RedirectToAction("Details", new { id = productDto.Id});
                //return RedirectToAction(nameof(Index));
            

        }
        private string UploadedFile(ShoesViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProductImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImage.CopyTo(fileStream);
                }
            }   
            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return RedirectToAction("Index");

            }
            return View(new ShoesViewModel
            {
                Id = product.Id,
                Image = product.Image,
                BrandName = product.BrandName,
                Title = product.Title,
                Genre = product.Genre,
                Price = product.Price,
                Size = product.Size,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete([FromForm] int id)
        {
            var product = _productService.Get(id);
            _productService.Delete(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Test = _brandService.GetAll();
            var product = _productService.Get(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            var model = new ShoesViewModel
            {
                Id = product.Id,
                Image = product.Image,
                BrandName = product.BrandName,
                Title = product.Title,
                Genre = product.Genre,
                Price = product.Price,
                Size = product.Size
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] ShoesViewModel shoesViewModel)
        {
            string uniqueFileName = UploadedFile(shoesViewModel);
            var product = _productService.Get(shoesViewModel.Id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                product.Id = shoesViewModel.Id;
                product.Image = uniqueFileName;
                product.BrandName = shoesViewModel.BrandName;
                product.Title = shoesViewModel.Title;
                product.Genre = shoesViewModel.Genre;
                product.Price = shoesViewModel.Price;
                product.Size = shoesViewModel.Size;

                _productService.Update(product);
            }
            return RedirectToAction("Details", new { id = shoesViewModel.Id });
            //return RedirectToAction("Index");
        }
        


    }
}