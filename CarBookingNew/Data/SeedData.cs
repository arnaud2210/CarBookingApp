using CarBookingNew.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingNew.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new CarDbContext(serviceProvider.GetRequiredService<DbContextOptions<CarDbContext>>());

            if (context.Cars.Any()) return;

            context.Cars.AddRange(
                new Car {Id = 1, Marque = "Peugeot", Modele = "208", Couleur = "Rouge", Carburant = FuelType.Essence, NombreDePlaces = 5, ImageUrl = "images/peugeot_208.jpg" },
                new Car {Id = 2, Marque = "Tesla", Modele = "Model 3", Couleur = "Noir", Carburant = FuelType.Electrique, NombreDePlaces = 5, ImageUrl = "images/tesla_model_3.jpg" },
                new Car {Id = 3, Marque = "Renault", Modele = "Clio", Couleur = "Bleu", Carburant = FuelType.Essence, NombreDePlaces = 4, ImageUrl = "images/renault_clio.jpg" }
            );

            context.SaveChanges();
        }
    }
}
