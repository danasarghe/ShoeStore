using Microsoft.AspNetCore.Http;
using ShoeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Web.Models
{
    public class ShoesViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Please enter brand name")]
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Required(ErrorMessage ="Please select type")]
        public Title Title { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please select size ")]
        public int Size { get; set; }
        [Required(ErrorMessage = "Please select type")]
        public Genre Genre { get; set; }
        public Brand Brand { get; set; }
        [Display(Name = "Photo")]
        public string Image { get; set; }
        public IFormFile ProductImage { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
