using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxNotes.Models;
using DbConnection;

namespace AjaxNotes.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        // Return all notes as JSON response
        [HttpGet("notes")]
        public IActionResult AllNotes()
        {
            string query = "SELECT * FROM notes ORDER BY created_at ASC;";
            var AllNotes = DbConnector.Query(query);
            return Json(AllNotes);
        }
        // Create new note and return as JSON repsonse 
        [HttpPost("create")]
        public IActionResult Create(Note model)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO notes (title, content, created_at, updated_at) VALUES('{model.NoteTitle}', '{model.NoteContent}', NOW(), NOW());";
                DbConnector.Execute(query);
                string queryLast = $"SELECT * FROM notes ORDER BY id DESC LIMIT 1;";
                var lastNote = DbConnector.Query(queryLast);
                return Json(lastNote);
            }
            return Json(new {Failed = "true"});
        }
        // Update note's title and return as JSON response
        [HttpPost("update/title/{id}")]
        public IActionResult UpdateTitle(Note model, int id)
        {
            string query = $"UPDATE notes SET title = '{model.NoteTitle}' WHERE id = {id};";
            DbConnector.Execute(query);
            string queryTitle = $"SELECT title FROM notes WHERE id = {id}";
            var newTitle = DbConnector.Query(queryTitle);
            return Json(newTitle);
        }
        // Update note's content and return as JSON response
        [HttpPost("update/content/{id}")]
        public IActionResult UpdateContent(Note model, int id)
        {
            string query = $"UPDATE notes SET content = '{model.NoteContent}' WHERE id = {id};";
            DbConnector.Execute(query);
            string queryContent = $"SELECT content FROM notes WHERE id = {id}";
            var newContent = DbConnector.Query(queryContent);
            return Json(newContent);
        }
        // Delete note 
        [HttpPost("delete/{id}")]
        public void Delete(int id)
        {
            string query = $"DELETE FROM notes WHERE id = {id};";
            DbConnector.Execute(query);
        }
    }
}
