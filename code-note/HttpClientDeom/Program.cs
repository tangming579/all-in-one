using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        private static string BASE_ADDRESS = "";
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
        }

        public class HttpClientTest
        {
            private static readonly HttpClient _httpClient;

            static HttpClientTest()
            {
                _httpClient = new HttpClient() { BaseAddress = new Uri(BASE_ADDRESS) };
                _httpClient.Timeout = TimeSpan.FromSeconds(15);

                //帮HttpClient热身
                _httpClient.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("HEAD"),
                    RequestUri = new Uri(BASE_ADDRESS + "/")
                })
                    .Result.EnsureSuccessStatusCode();
            }

            public async Task<string> PostAsync(string strJson)
            {
                HttpContent content = new StringContent(strJson);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _httpClient.PostAsync("/", content);
                
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
