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
    public class SettingController : Controller
    {
        private ShopContext _context;
        public SettingController(ShopContext context)
        {
            _context = context;
        }
        // GET: /settings
        [HttpGet("settings")]
        public IActionResult Index()
        {
            ProductModels data = new ProductModels
            {
                MultipleProducts = _context.Products.OrderBy(p => p.ProductName).ToList(),
                Product = new Product(),
            };
            return View(data);
        }
        // POST: /settings/products/update 
        [HttpPost("settings/products/update")]
        public IActionResult Update(ProductModels model)
        {
            Product product = _context.Products.Where(p => p.ID == model.Product.ID).SingleOrDefault();
            product.ProductQuantity += model.Product.ProductQuantity;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
