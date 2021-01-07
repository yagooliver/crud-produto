using CrudBackend.Domain.Core.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudBackend.Domain.Core.Shared.Helper
{
    public static class AutenticaRequest
    {
        private static string uri;
        static AutenticaRequest()
        {
            uri = "https://dev.sitemercado.com.br/api/login";
        }

        public static async Task<ResultadoApi> LoginAsync(string login, string senha)
        {
            try
            {
                var _socketHandler = new SocketsHttpHandler()
                {
                    PooledConnectionLifetime = TimeSpan.FromMinutes(1),
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),
                };

                using (var _httpClient = new HttpClient(_socketHandler))
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(uri)
                    };

                    var byteArray = Encoding.ASCII.GetBytes($"{login}:{senha}");
                    _httpClient.Timeout = TimeSpan.FromMinutes(1);
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var response = await _httpClient.SendAsync(request);

                    response.EnsureSuccessStatusCode();

                    return JsonConvert.DeserializeObject<ResultadoApi>(await response.Content.ReadAsStringAsync());
                }
            }
            catch(Exception e)
            {
                return await Task.FromResult(new ResultadoApi() { Success = false, Error = e.Message });
            }
        }
    }
}
