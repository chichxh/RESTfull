using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class SectionService : ApiService, ISectionService
    {
        public SectionService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Section>> GetAllSectionsAsync()
        {
            var result = await GetAsync<List<Section>>("api/sections");
            return result ?? new List<Section>();
        }

        public async Task<Section?> GetSectionByIdAsync(int id)
        {
            return await GetAsync<Section>($"api/sections/{id}");
        }

        public async Task CreateSectionAsync(Section section)
        {
            await PostAsync("api/sections", section);
        }

        public async Task UpdateSectionAsync(Section section)
        {
            await PutAsync($"api/sections/{section.Id}", section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            await DeleteAsync($"api/sections/{id}");
        }
    }
}

