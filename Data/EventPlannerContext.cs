#define First // LAST First
#if First
#region snippet_first
using EventsFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsFactory.Data
{
    public class EventPlannerContext : DbContext
    {
        public EventPlannerContext (DbContextOptions<EventPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Participant>().ToTable("Participant");
        }
    }
}
#endregion
#elif LAST
#endif