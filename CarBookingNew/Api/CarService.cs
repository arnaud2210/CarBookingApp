using CarBookingNew.Data;
using CarBookingNew.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingNew.Api
{
    public class CarService
    {
        private readonly CarDbContext _context;

        public CarService(CarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync() =>
            await _context.Cars.ToListAsync();

        public async Task<List<Car>> FilterCarsAsync(string? couleur, FuelType? carburant, int? nbPlaces, string? modele)
        {
            var query = _context.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(couleur))
                query = query.Where(c => c.Couleur == couleur);

            if (carburant.HasValue)
                query = query.Where(c => c.Carburant == carburant.Value);

            if (nbPlaces.HasValue)
                query = query.Where(c => c.NombreDePlaces == nbPlaces.Value);

            if (!string.IsNullOrWhiteSpace(modele))
                query = query.Where(c => c.Modele.Contains(modele));

            return await query.ToListAsync();
        }

        public async Task ToggleReservationAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                car.EstReservee = !car.EstReservee;
                await _context.SaveChangesAsync();
            }
        }
    }
}
