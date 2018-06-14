using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class User : BaseEntity 
    {
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public double Balance {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Transaction> Transactions {get; set;}
        public User()
        {
            Transactions = new List<Transaction>();
            Balance = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
    public class UserRegister : BaseEntity
    {
        [Required(ErrorMessage = "First name is required")] 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First name cannot contain numbers or special characters")]       
        public string FirstName {get; set;}

        [Required(ErrorMessage = "Last name is required")] 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last name cannot contain numbers or special characters")]
        public string LastName {get; set;}

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        public string Password {get; set;}

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword {get; set;}
    }
    public class UserLogin : BaseEntity
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

    }
}