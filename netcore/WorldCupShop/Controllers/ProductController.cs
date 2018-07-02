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
    public class ProductController : Controller
    {
        private ShopContext _context;
        public ProductController(ShopContext context)
        {
            _context = context;
        }
        // GET: /products
        [HttpGet("products")]
        public IActionResult Index()
        {
            ProductModels data = new ProductModels
            {
                MultipleProducts = _context.Products.OrderBy(p => p.ProductName).Take(12).ToList(),
                Product = new Product()
            };
            return View(data);
        }
        // POST: /products/new
        [HttpPost("products/new")]
        public IActionResult New(ProductModels model)
        {
            model.MultipleProducts = _context.Products.OrderBy(p => p.ProductName).Take(12).ToList();
            if(ModelState.IsValid)
            {
                Product product = new Product 
                {
                    ProductName = model.Product.ProductName,
                    ImageURL = model.Product.ImageURL,
                    ProductDescription = model.Product.ProductDescription,
                    ProductQuantity = model.Product.ProductQuantity
                };
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }
        // GET: /products/all
        [HttpGet("products/all")]
        public IActionResult ShowAll()
        {
            ProductModels data = new ProductModels
            {
                MultipleProducts = _context.Products.OrderBy(p => p.ProductName).ToList(),
                Product = new Product()
            };
            return View("Index", data);
        }
    }
}
