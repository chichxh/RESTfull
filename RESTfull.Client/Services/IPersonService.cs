using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person?> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}

