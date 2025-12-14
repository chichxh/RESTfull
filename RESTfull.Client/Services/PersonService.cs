using RESTfull.Domain.Entities;

namespace RESTfull.Client.Services
{
    public class PersonService : ApiService, IPersonService
    {
        public PersonService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            var result = await GetAsync<List<Person>>("api/persons");
            return result ?? new List<Person>();
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await GetAsync<Person>($"api/persons/{id}");
        }

        public async Task CreatePersonAsync(Person person)
        {
            await PostAsync("api/persons", person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await PutAsync($"api/persons/{person.Id}", person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await DeleteAsync($"api/persons/{id}");
        }
    }
}

