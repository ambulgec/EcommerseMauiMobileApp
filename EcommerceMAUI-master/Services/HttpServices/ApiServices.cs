using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EcommerceMAUI.Services.HttpServices
{
    public class ApiService : IApiServices 
    {

        private readonly HttpClient _httpClient;
        private string kl;
        private string endpoint;

        private const string BaseApiUrl = "https://makeup-api.herokuapp.com/api/v1/";

       

        public ApiService()
        {
            _httpClient = new HttpClient();
         
        }

        public Task<TResponse> DeleteAsync<TResponse>(string endpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> GetAsync<TResponse>(string apiRelativeUrl)

        {
            var fullApiUrl = BaseApiUrl + apiRelativeUrl;
            var response = await _httpClient.GetAsync(fullApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(content);
            }

            return JsonConvert.DeserializeObject<TResponse>(kl);

        
        }

      

        public Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            throw new NotImplementedException();
        }


    }
}
