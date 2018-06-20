using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options) : base(options) {}
        public DbSet<User> Users {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<RSVP> RSVPs {get; set;}
    }
}