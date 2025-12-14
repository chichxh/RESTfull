using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public interface ISectionService
    {
        Task<List<Section>> GetAllSectionsAsync();
        Task<Section?> GetSectionByIdAsync(int id);
        Task CreateSectionAsync(Section section);
        Task UpdateSectionAsync(Section section);
        Task DeleteSectionAsync(int id);
    }
}

