using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "First name must contain at least 2 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "First name cannot contain numbers or special characters")]
        public string FirstName {get; set;}
        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2, ErrorMessage = "Last name must contain at least 2 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Last name cannot contain numbers or special characters")]
        public string LastName {get; set;}
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email entered")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters longs")]
        public string Password {get; set;}
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}
    }
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email entered")]
        public string LoginEmail {get; set;}
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string LoginPassword {get; set;}
    }
}