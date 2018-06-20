namespace WeddingPlanner.Models
{
    public class RSVP : BaseEntity
    {
        public int ID {get; set;}
        public User User {get; set;}
        public int UserID {get; set;}
        public Wedding Wedding {get; set;}
        public int WeddingID {get; set;}
    }
}