using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WorldCupShop.Models
{
    public class Product : BaseEntity
    {
        public int ID {get; set;}
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName {get; set;}
        [Required]
        [Display(Name = "Image URL")]
        public string ImageURL {get; set;}
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription {get; set;}
        public int ProductQuantity {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Order> Orders {get; set;}
        public Product()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Orders = new List<Order>();
        }
    }
    public class ProductModels : BaseEntity 
    {
        public Product Product {get; set;}
        public List<Product> MultipleProducts {get; set;}
    }   
}