using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StoreBlzr.Shared.Dto;

namespace StoreBlzr.Shared.Services.Auth
{
    public class AuthDataService : IAuthDataService
    {
        private readonly HttpClient _httpClient;
        public AuthDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<AuthModel> GetTokenAsync(Login model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AuthModel> RegisterAsync(UserModel model)
        {
            model.Id = Guid.NewGuid().ToString();

            var userJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Auth/Register", userJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<AuthModel>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }
    }
}