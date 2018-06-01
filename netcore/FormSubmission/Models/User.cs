using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission
{
    public class User : BaseEntity
    {
        public int Id {get; set;}
        // User first name
        [Required(ErrorMessage = "First name is required")]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters long")]
        public string FirstName {get; set;}
        // User last name
        [Required(ErrorMessage = "Last name is required")]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters long")]
        public string LastName {get; set;}
        // User age
        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be greater than 0")]
        public int? Age {get; set;}
        // User email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email {get; set;}
        // User password
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}