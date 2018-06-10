using System;
using System.ComponentModel.DataAnnotations;

namespace TrailTracker.Models
{
    public class Trail 
    {
        public int ID {get; set;}
        [Required(ErrorMessage = "Trail name is required")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage= "Description must contain at least 10 characters")]
        public string Description {get; set;}
        [Required(ErrorMessage = "Trail length is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Lenght of trail can't be negative")]
        [RegularExpression("^[0-9-]*$", ErrorMessage = "Length must be numeric")]
        public double? Length {get; set;}
        [Required(ErrorMessage = "Elevation change is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Elevation change can't be negative")]
        [RegularExpression("^[0-9-]*$", ErrorMessage = "Elevation change must be numeric")]
        public int? Elevation {get; set;}
        [Required(ErrorMessage = "Longitude is required")]
        [Range(-180.0, 180.0, ErrorMessage = "Longitude must range from -180.0 to 180.0")]
        public double? Longitude {get; set;}
        [Required(ErrorMessage = "Latitude is required")]
        [Range(-90.0, 90.0, ErrorMessage = "Latitude must range from -90.0 to 90.0")]
        public double? Latitude {get; set;}
        public DateTime CreatedAt {get; set;}
    }
}