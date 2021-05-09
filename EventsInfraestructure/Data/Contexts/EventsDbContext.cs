using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using EventsCore.Entities;

namespace EventsInfraestructure.Data.Contexts
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasKey(k => k.Id);
            modelBuilder.Entity<Category>().Property(k => k.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(p => p.Events)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Event>().HasKey(k => k.Id);
            modelBuilder.Entity<Event>().Property(k => k.Id).ValueGeneratedOnAdd();

            //seeding
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                CategoryName = "Concert"
            }, new Category
            {
                Id = 2,
                CategoryName = "Theaters"
            });
        }
    }
}