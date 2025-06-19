namespace CarBookingApp.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public bool Electric { get; set; }

        public int SeatCount { get; set; }

        public bool IsReserved { get; set; }
    }
}
