using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class UserReg : BaseEntity
    {
        public int ID {get; set;}
        // User first name 
        [Required(ErrorMessage = "First name is requried")]
        [MinLength(2, ErrorMessage = "First name must have at least two characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "First name cannot contain numbers or special characters")]
        public string FirstName {get; set;}
        // User last name 
        [Required(ErrorMessage = "Last name is requried")]
        [MinLength(2, ErrorMessage = "Last name must have at least two characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Last name cannot contain numbers or special characters")]
        public string LastName {get; set;}
        // User email 
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "An invalid email was entered")]
        public string Email {get; set;}
        // User password 
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least eight characters long")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        // User confirm password 
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}
    }
    public class UserLog : BaseEntity 
    {
         // User email 
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "An invalid email was entered")]
        public string LogEmail {get; set;}
        // User password 
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string LogPassword {get; set;}
    }
}