using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }
}

