using System.Net.Http.Json;

namespace RESTfull.Client.Services
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T?> GetAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected async Task PostAsync<TRequest>(string uri, TRequest data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(uri, data);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Ошибка при создании записи: {response.StatusCode} - {errorContent}");
                }
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Ошибка HTTP запроса: {ex.Message}", ex);
            }
        }

        protected async Task<TResponse?> PutAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        protected async Task PutAsync<TRequest>(string uri, TRequest data)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, data);
            response.EnsureSuccessStatusCode();
        }

        protected async Task DeleteAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }
    }
}

