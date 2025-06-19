using CarBookingApp.Data.Models;
using System.Net.Http.Json;


namespace CarBookingApp.Services
{
    public class CarService
    {
        private readonly HttpClient _httpClient;
        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress ??= new Uri("https://localhost:5001/");
        }

        public async Task<List<Car>> GetCars() => 
            await _httpClient.GetFromJsonAsync<List<Car>>("api/cars") ?? new();

        public async Task ToggleReservation(int id) =>
            await _httpClient.PostAsync($"api/cars/{id}/toggle", null);
    }
}
