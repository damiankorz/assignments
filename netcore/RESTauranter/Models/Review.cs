using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review 
    {
        public int ID {get; set;}
        [Required(ErrorMessage = "Reviewer name is required")]
        public string ReviewerName {get; set;}
        [Required(ErrorMessage = "Restaurant name is required")]
        public string RestaurantName {get; set;}
        [Required(ErrorMessage = "Restaurant review is required")]
        [MinLength(10, ErrorMessage = "Restaturant review must have at least 10 characters")]
        public string RestaurantReview {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [RestrictedDate(ErrorMessage = "Date cannot be a future date")]
        [Display(Name = "Date Visited")]
        public DateTime DateVisited {get; set;}
        public int Rating {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}