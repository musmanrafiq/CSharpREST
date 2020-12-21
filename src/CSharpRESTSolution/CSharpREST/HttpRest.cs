using CSharpREST.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CSharpREST
{
    public class HttpRest
    {
        private bool IsStrictRestful { get; init; }

        public HttpRest(bool enforceRest = false)
        {
            IsStrictRestful = enforceRest;
        }
        public async Task<(T, Error)> GetAsyn<T>(string url)
        {
            try
            {
                using HttpClient _httpClient = new HttpClient();
                var response = await _httpClient.GetFromJsonAsync<T>(url);
                return (response, null);
            }
            catch (Exception exp)
            {
                return (default(T), new Error { Message = exp.Message });
            }
        }
    }
}
