namespace Eventmi.Infrastructure.Data
{

    using Eventmi.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventmiDbContext : DbContext
    {
        public EventmiDbContext()
        {

        }
        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
    }
}
