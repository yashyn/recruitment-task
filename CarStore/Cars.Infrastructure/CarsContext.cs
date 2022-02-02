using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infrastructure
{
    public class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO pass from environment variable
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=admin;Database=recrtask;SSL Mode=Disable;Port=5432");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}