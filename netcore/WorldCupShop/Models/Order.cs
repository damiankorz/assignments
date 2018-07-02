using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WorldCupShop.Models
{
    public class Order : BaseEntity
    {
        public int ID {get; set;}
        public int CustomerID {get; set;}
        public Customer Customer {get; set;}
        public int ProductID {get; set;}
        public Product Product {get; set;}
        [Required]
        [Display(Name = "Order Quantity")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Order quantity may not contain letters or special characters")]
        [Range(1, int.MaxValue, ErrorMessage = "Order quantity must be at least 1")]
        public int OrderQuantity {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public Order()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
    public class OrderModels : BaseEntity
    {
        public List<Customer> Customers {get; set;}
        public List<Product> Products {get; set;}
        public List<Order> Transactions {get; set;}
        public Order Orders {get; set;}
    }
}