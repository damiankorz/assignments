using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity 
    {
        public int ID {get; set;}
        public int UserID {get; set;}
        public string Groom {get; set;}
        public string Bride {get; set;}
        public DateTime Date {get; set;}
        public string Address {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<RSVP> Attendees {get; set;}
        public Wedding ()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Attendees = new List<RSVP>();
        }
    }
    // Validation attribute for future date
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime inputDate = (DateTime)date;
            return inputDate > DateTime.Now;
        }
    }
    public class WeddingCreation : BaseEntity
    {
        [Required(ErrorMessage = "Groom name is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Groom name must not contain numbers or special characters")]
        public string Groom {get; set;}

        [Required(ErrorMessage = "Bride name is required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Bride name must not contain numbers or special characters")]
        public string Bride {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [RestrictedDate(ErrorMessage = "Date must be set in the future")]
        public DateTime Date {get; set;}

        [Required(ErrorMessage = "Address is required")]
        public string Address {get; set;}

    }
    public class DashViewModels 
    {
        public List<Wedding> AllWeddings {get; set;}
        public User User {get; set;}
    }
}