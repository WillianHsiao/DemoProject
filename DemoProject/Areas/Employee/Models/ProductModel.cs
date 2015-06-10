using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.Areas.Employee.Models
{
    public class ProductModel
    {
        [Required]
        public Guid PK { get; set; }
        [Required]
        [Display(Name = "產品名稱")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "價格")]
        public int Price { get; set; }

        [Display(Name = "產品敘述")]
        public string Description { get; set; }
        public List<ProductModel> ProductList { get; set; }
    }
}