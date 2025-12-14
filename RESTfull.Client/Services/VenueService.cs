using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class VenueService : ApiService, IVenueService
    {
        public VenueService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Venue>> GetAllVenuesAsync()
        {
            var result = await GetAsync<List<Venue>>("api/venues");
            return result ?? new List<Venue>();
        }

        public async Task<Venue?> GetVenueByIdAsync(int id)
        {
            return await GetAsync<Venue>($"api/venues/{id}");
        }

        public async Task CreateVenueAsync(Venue venue)
        {
            await PostAsync("api/venues", venue);
        }

        public async Task UpdateVenueAsync(Venue venue)
        {
            await PutAsync($"api/venues/{venue.Id}", venue);
        }

        public async Task DeleteVenueAsync(int id)
        {
            await DeleteAsync($"api/venues/{id}");
        }
    }
}

