using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class RoleService : ApiService, IRoleService
    {
        public RoleService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var result = await GetAsync<List<Role>>("api/roles");
            return result ?? new List<Role>();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await GetAsync<Role>($"api/roles/{id}");
        }

        public async Task CreateRoleAsync(Role role)
        {
            await PostAsync("api/roles", role);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await PutAsync($"api/roles/{role.Id}", role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await DeleteAsync($"api/roles/{id}");
        }
    }
}

