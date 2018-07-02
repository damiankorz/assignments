using Microsoft.AspNetCore;
using System.Collections.Generic;

namespace WorldCupShop.Models
{
    public class HomeModels
    {
        public List<Product> AllProducts {get; set;}
        public List<Customer> AllCustomers {get; set;}
        public List<Order> AllOrders {get; set;}

    }
}