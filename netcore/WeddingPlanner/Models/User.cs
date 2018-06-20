using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<RSVP> RSVPS {get; set;}
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now; 
            RSVPS = new List<RSVP>();
        }
    }
    public class UserRegister : BaseEntity
    {
        [Required(ErrorMessage = "First name is requried")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First name must not contain numbers or special characters")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        public string FirstName {get; set;}
        
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Last name must not contain numbers or special characters")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        public string LastName {get; set;}

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Invalid password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password {get; set;}

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}
    }
    public class UserLogin : BaseEntity 
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string LoginEmail {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string LoginPassword {get; set;}
    }
    public class UserViewModels
    {
        public UserRegister Registration {get; set;}
        public UserLogin Login {get; set;}
    }
}