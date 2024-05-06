using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.KitchenConnectionContext
{
    public class HotelDbContext : DbContext, IHotelDbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            Database.EnsureCreated();
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<Group> Group { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
