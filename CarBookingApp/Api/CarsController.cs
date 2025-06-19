using CarBookingApp.Data;
using CarBookingApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Car>> GetCars() => await _context.Cars.ToListAsync();

        [HttpPost("{id}/toggle")]
        public async Task<IActionResult> ToggleReservation(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null) return NotFound();

            car.IsReserved = !car.IsReserved;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    
}
