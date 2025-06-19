namespace CarBookingNew.Data.Models
{
    public class CarFilter
    {
        public string? Couleur { get; set; }
        public FuelType? Carburant { get; set; }
        public int? Places { get; set; }
        public string? Modele { get; set; }
    }
}
