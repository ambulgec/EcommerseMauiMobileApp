using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.Services.HttpServices
{
    public interface IApiServices
    {

        Task<TResponse> GetAsync<TResponse>(string endpoint);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task<TResponse> DeleteAsync<TResponse>(string endpoint);
    }
}
