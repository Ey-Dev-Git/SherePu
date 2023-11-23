//using Esprima;
using Microsoft.EntityFrameworkCore;
using Module.Models;
//using OrchardCore.Workflows.Activities;

namespace Module.Data
{
    public class ApplicationDBContext : DbContext
    {
        public  ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<Hostels> Hostels { get; set; }
        public DbSet<LocationTravels> LocationTravels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationTravels>()
                        .HasMany(t => t.Activities)
                        .WithOne(s => s.LocationTravel)
                        .HasForeignKey(s => s.LocationTravelID)
                        .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
