using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Message 
    {
        [Required(ErrorMessage = "Message cannot be blank")]
        public string MessageContent {get; set;}
    }
}