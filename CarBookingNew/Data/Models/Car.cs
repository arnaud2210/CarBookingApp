using Microsoft.VisualBasic.FileIO;

namespace CarBookingNew.Data.Models
{
    public enum FuelType { Essence, Electrique }

    public class Car
    {
        public int Id { get; set; }
        public string Marque { get; set; } = string.Empty;
        public string Modele { get; set; } = string.Empty;
        public string Couleur { get; set; } = string.Empty;
        public FuelType Carburant { get; set; }
        public int NombreDePlaces { get; set; }
        public bool EstReservee { get; set; } = false;
    }
}
