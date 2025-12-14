using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public interface IDirectionService
    {
        Task<List<Direction>> GetAllDirectionsAsync();
        Task<Direction?> GetDirectionByIdAsync(int id);
        Task CreateDirectionAsync(Direction direction);
        Task UpdateDirectionAsync(Direction direction);
        Task DeleteDirectionAsync(int id);
    }
}

