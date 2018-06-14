using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Transaction : BaseEntity
    {
        public int ID {get; set;}
        public int UserID {get; set;}
        public User User {get; set;}
        public double Amount {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public Transaction()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
    public class TransactionValidation : BaseEntity 
    {
        [Required]
        [RegularExpression(@"^-?[0-9]\d*(\.\d+)?$")]
        public double Amount {get; set;}
    }
}