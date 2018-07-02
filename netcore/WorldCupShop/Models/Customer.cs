using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WorldCupShop.Models
{
    public class Customer : BaseEntity
    {
        public int ID {get; set;}
        [Required]
        [Display(Name = "Customer Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Customer name may not contain any special characters")]
        public string CustomerName {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Order> Orders {get; set;}
        public Customer()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Orders = new List<Order>();
        }
    }
    public class CustomerModels 
    {
        public Customer Customer {get; set;}
        public List<Customer> AllCustomers {get; set;}
    }
}