using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public interface IConferenceService
    {
        Task<List<Conference>> GetAllConferencesAsync();
        Task<Conference?> GetConferenceByIdAsync(int id);
        Task CreateConferenceAsync(Conference conference);
        Task UpdateConferenceAsync(Conference conference);
        Task DeleteConferenceAsync(int id);
    }
}

