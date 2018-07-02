using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WorldCupShop.Models;

namespace WorldCupShop.Controllers
{
    public class CustomerController : Controller
    {
        private ShopContext _context;
        public CustomerController(ShopContext context)
        {
            _context = context;
        }
        // GET: /customers
        [HttpGet("customers")]
        public IActionResult Index()
        {
            CustomerModels data = new CustomerModels
            {
                AllCustomers = _context.Customers.ToList(),
                Customer = new Customer()
            };
            return View(data);
        }
        // POST: /customers/new
        [HttpPost("customers/new")]
        public IActionResult New(CustomerModels model)
        {
            model.AllCustomers = _context.Customers.ToList();
            if(ModelState.IsValid)
            {
                List<Customer> customers = _context.Customers.Where(c => c.CustomerName == model.Customer.CustomerName).ToList();
                if(customers.Count > 0)
                {
                    ModelState.AddModelError("CustomerName", "Customer already exists");
                    return View("Index", model);
                }
                else
                {
                    Customer newCustomer = new Customer
                    {
                        CustomerName = model.Customer.CustomerName
                    };
                    _context.Add(newCustomer);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("Index", model);
        }
        // GET: /customers/id/delete
        [HttpGet("customers/{id}/delete")]
        public IActionResult Remove(int id)
        {
            List<Order> orders = _context.Orders.ToList();
            orders.RemoveAll(x => x.CustomerID == id);
            _context.SaveChanges();
            Customer customer = _context.Customers.Where(c => c.ID == id).SingleOrDefault();
            _context.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
