using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxNotes.Models
{
   public class Note : BaseEntity
   {
       public int NoteID {get; set;}
       [Required]
       public string NoteTitle {get; set;}
       [Required]
       public string NoteContent {get; set;}
       public DateTime CreatedAt {get; set;}
       public DateTime UpdatedAt {get; set;}
   }
}