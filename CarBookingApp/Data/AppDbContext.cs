using CarBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Renault", Model = "Clio", Color = "Red", Electric = false, SeatCount = 5, IsReserved = false },
                new Car { Id = 2, Brand = "Tesla", Model = "Model 3", Color = "Black", Electric = true, SeatCount = 5, IsReserved = false }
                );
        }
    }
}
