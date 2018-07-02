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
    public class OrderController : Controller
    {
        private ShopContext _context;
        public OrderController(ShopContext context)
        {
            _context = context;
        }
        // GET: /orders
        [HttpGet("orders")]
        public IActionResult Index()
        {
            OrderModels data = new OrderModels
            {
                Products = _context.Products.OrderBy(p => p.ProductName).ToList(),
                Customers = _context.Customers.OrderBy(c => c.CustomerName).ToList(),
                Transactions = _context.Orders.Include(o => o.Customer).Include(o => o.Product).ToList(),
                Orders = new Order(),
            };
            return View(data);
        }
        // POST: /orders/new
        public IActionResult New(OrderModels model)
        {
            model.Products = _context.Products.OrderBy(p => p.ProductName).ToList();
            model.Customers = _context.Customers.OrderBy(c => c.CustomerName).ToList();
            model.Transactions = _context.Orders.Include(o => o.Customer).Include(o => o.Product).ToList();
            if(ModelState.IsValid)
            {
                Product item = _context.Products.Where(p => p.ID == model.Orders.ProductID).SingleOrDefault();
                if(model.Orders.OrderQuantity >= item.ProductQuantity)
                {
                    ModelState.AddModelError("OrderQuanity", $"Quantity exceeds inventory. {item.ProductQuantity} remain in stock.");
                }
                else
                {
                    Order newOrder = new Order 
                    {
                        CustomerID = model.Orders.CustomerID,
                        ProductID = model.Orders.ProductID,
                        OrderQuantity = model.Orders.OrderQuantity
                    };
                    item.ProductQuantity -= model.Orders.OrderQuantity;
                    _context.Add(newOrder);
                    _context.SaveChanges();
                    return RedirectToAction("Index", model);
                }
            }
            return View("Index", model);
        }
    }
}
