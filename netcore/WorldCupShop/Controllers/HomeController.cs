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
    public class HomeController : Controller
    {
        private ShopContext _context;
        public HomeController(ShopContext context)
        {
            _context = context;
        }
        // GET: /
        [HttpGet("")]
        public IActionResult Index()
        {
            HomeModels data = new HomeModels
            {
                AllProducts = _context.Products.OrderBy(p => p.ProductName).Take(4).ToList(),
                AllCustomers = _context.Customers.OrderByDescending(c => c.CreatedAt).Take(3).ToList(),
                AllOrders = _context.Orders.Include(o => o.Customer).Include(o => o.Product).OrderByDescending(o => o.CreatedAt).Take(3).ToList()
            };
            return View(data);
        }
        // GET: /all/products
        [HttpGet("all/products")]
        public IActionResult ShowProducts()
        {
            HomeModels data = new HomeModels
            {
                AllProducts = _context.Products.OrderBy(p => p.ProductName).ToList(),
                AllCustomers = _context.Customers.OrderByDescending(c => c.CreatedAt).Take(3).ToList(),
                AllOrders = _context.Orders.Include(o => o.Customer).Include(o => o.Product).OrderByDescending(o => o.CreatedAt).Take(3).ToList()
            };
            return View("Index", data);
        }
        // GET: /all/orders
        [HttpGet("all/orders")]
        public IActionResult ShowOrders()
        {
            HomeModels data = new HomeModels
            {
                AllProducts = _context.Products.OrderBy(p => p.ProductName).Take(4).ToList(),
                AllCustomers = _context.Customers.OrderByDescending(c => c.CreatedAt).Take(3).ToList(),
                AllOrders = _context.Orders.Include(o => o.Customer).Include(o => o.Product).OrderByDescending(o => o.CreatedAt).ToList()
            };
            return View("Index", data);
        }
        // GET: /all/customers
        [HttpGet("all/customers")]
        public IActionResult ShowCustomers()
        {
            HomeModels data = new HomeModels
            {
                AllProducts = _context.Products.OrderBy(p => p.ProductName).Take(4).ToList(),
                AllCustomers = _context.Customers.OrderByDescending(c => c.CreatedAt).ToList(),
                AllOrders = _context.Orders.Include(o => o.Customer).Include(o => o.Product).OrderByDescending(o => o.CreatedAt).Take(3).ToList()
            };
            return View("Index", data);
        }
    }
}
