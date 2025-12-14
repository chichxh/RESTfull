using RESTfull.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RESTfull.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Index для AreaIndex в сочетании с AreaType
            modelBuilder.Entity<Role>()
                .HasIndex(r => new { r.AreaIndex, r.AreaType })
                .IsUnique();

            // Person → Roles (один ко многим)
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Roles)
                .WithOne(r => r.Person)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
