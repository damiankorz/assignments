using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Forum.Models;

namespace Forum
{
     public class ForumController : Controller
     {
        private readonly DbConnector _dbConnector;
        public ForumController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /forum
        [HttpGet("forum")]
        public IActionResult Index()
        {
            // Check if user ID is null, if true redirect to index
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                return RedirectToAction("Index", "User");
            }
            ViewBag.AllMessages = AllMessages();
            ViewBag.AllComments = AllComments();
            ViewBag.User = _dbConnector.Query($"SELECT * FROM users WHERE id = {(int)HttpContext.Session.GetInt32("userID")}");
            ViewBag.UserID = (int)HttpContext.Session.GetInt32("userID");
            return View();
        }
        // POST: /messages/create
        [HttpPost("messages/create")]
        public IActionResult CreateMessage(ForumModels forumModels)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO messages (user_id, message, created_at, updated_at) VALUES ({(int)HttpContext.Session.GetInt32("userID")}, '{forumModels.MessagePost.MessageContent}', NOW(), NOW());";
                _dbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            else 
            {
                // Return validation error and store in TempData
                foreach(var modelState in ModelState.Values)
                {
                    foreach(var error in modelState.Errors)
                    {
                        TempData["errors"] = error.ErrorMessage;

                    }
                }
                return RedirectToAction("Index");
            }
        }
        // POST: /comments/create
        [HttpPost("comments/create")]
        public IActionResult CreateComment(ForumModels forumModels)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO comments (message_id, user_id, comment, created_at, updated_at) VALUES ('{forumModels.CommentPost.MessageID}', {(int)HttpContext.Session.GetInt32("userID")}, '{forumModels.CommentPost.CommentContent}', NOW(), NOW());";
                _dbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            else 
            {
                // Return validation error and store in TempData
                foreach(var modelState in ModelState.Values)
                {
                    foreach(var error in modelState.Errors)
                    {
                        TempData["errors"] = error.ErrorMessage;

                    }
                }
                return RedirectToAction("Index");
            }
        }
        // GET: /delete/message
        [HttpGet("delete/message/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            string query = $"DELETE FROM comments WHERE message_id = {id}; DELETE FROM messages WHERE id = {id};";
            _dbConnector.Execute(query);
            return RedirectToAction("Index");
        }
        // Query all messages and return list
        public List<Dictionary<string,object>> AllMessages()
        {
            string query = "SELECT messages.id AS message_id, messages.message, messages.created_at, users.id AS user_id, users.first_name, users.last_name FROM messages JOIN users ON messages.user_id = users.id ORDER BY created_at DESC;";
            return _dbConnector.Query(query);
        }
        // Query all comments and return list
        public List<Dictionary<string, object>> AllComments()
        {
            string query = "SELECT comments.id AS comment_id, comments.message_id, comments.comment, comments.created_at, users.id AS user_id,users.first_name, users.last_name FROM comments JOIN messages ON comments.message_id = messages.id JOIN users ON comments.user_id = users.id;";
            return _dbConnector.Query(query);
        }
     }
}