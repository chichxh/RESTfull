using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class DirectionService : ApiService, IDirectionService
    {
        public DirectionService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Direction>> GetAllDirectionsAsync()
        {
            var result = await GetAsync<List<Direction>>("api/directions");
            return result ?? new List<Direction>();
        }

        public async Task<Direction?> GetDirectionByIdAsync(int id)
        {
            return await GetAsync<Direction>($"api/directions/{id}");
        }

        public async Task CreateDirectionAsync(Direction direction)
        {
            await PostAsync("api/directions", direction);
        }

        public async Task UpdateDirectionAsync(Direction direction)
        {
            await PutAsync($"api/directions/{direction.Id}", direction);
        }

        public async Task DeleteDirectionAsync(int id)
        {
            await DeleteAsync($"api/directions/{id}");
        }
    }
}

