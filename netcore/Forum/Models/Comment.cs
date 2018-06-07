using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Comment 
    {
        [Required(ErrorMessage = "Comment cannot be blank")]
        public string CommentContent {get; set;}
        public int MessageID {get; set;}
    }
}