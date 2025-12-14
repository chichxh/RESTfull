using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class ConferenceService : ApiService, IConferenceService
    {
        public ConferenceService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Conference>> GetAllConferencesAsync()
        {
            var result = await GetAsync<List<Conference>>("api/conferences");
            return result ?? new List<Conference>();
        }

        public async Task<Conference?> GetConferenceByIdAsync(int id)
        {
            return await GetAsync<Conference>($"api/conferences/{id}");
        }

        public async Task CreateConferenceAsync(Conference conference)
        {
            await PostAsync("api/conferences", conference);
        }

        public async Task UpdateConferenceAsync(Conference conference)
        {
            await PutAsync($"api/conferences/{conference.Id}", conference);
        }

        public async Task DeleteConferenceAsync(int id)
        {
            await DeleteAsync($"api/conferences/{id}");
        }
    }
}

