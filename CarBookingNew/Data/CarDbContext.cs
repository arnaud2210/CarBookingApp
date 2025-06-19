using CarBookingNew.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarBookingNew.Data
{
    public class CarDbContext: DbContext
    {
        public DbSet<Car> Cars => Set<Car>();

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

    }
}
