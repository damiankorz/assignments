using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Bank.Models;

namespace Bank
{
    public class TransactionController : Controller
    {
        private AccountContext _context;
        public TransactionController(AccountContext context)
        {
            _context = context;
        }
        // GET: /account/id
        [HttpGet("accounts/{id}")]
        public IActionResult Index(int id)
        {
            // check if user id is in session, if false redirect to login 
            if(HttpContext.Session.GetInt32("userID") == null)
            {
                return RedirectToAction("Login", "User");
            }
            // check if route id matches session id to prevent logged user from accessing another users' account
            if(id != HttpContext.Session.GetInt32("userID"))
            {
                return RedirectToAction("Index", new{id = HttpContext.Session.GetInt32("userID")});
            }
            return View(_context.Users.Include(u => u.Transactions).Where(u => u.ID == id).SingleOrDefault());
        }
        // POST: /accounts/id/process
        [HttpPost("accounts/{id}/process")]
        public IActionResult ProcessTransaction(TransactionValidation model, int id)
        {
            if(ModelState.IsValid)
            {
                User user = _context.Users.Where(u => u.ID == id).SingleOrDefault();
                // Check if amount is a withdrawl and if there are available funds to pull
                if(model.Amount < 0 && ((model.Amount * -1) > user.Balance))
                {
                    TempData["errors"] = "Insufficient funds";
                    return RedirectToAction("Index", new{id = id});
                }
                else
                {
                    Transaction withdrawal = new Transaction
                    {
                        Amount = model.Amount,
                        User = user
                    };
                    user.Balance += model.Amount;
                    _context.Transactions.Add(withdrawal);
                    _context.SaveChanges();
                    return RedirectToAction("Index", new{id = id});
                }
                
            }
            foreach(var modelState in ModelState.Values)
            {
                foreach(var error in modelState.Errors)
                {
                    TempData["errors"] = error.ErrorMessage;
                }
            }
            return RedirectToAction("Index", new{id = id});
        }
        // GET: /logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // clear session and redirect to login
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}