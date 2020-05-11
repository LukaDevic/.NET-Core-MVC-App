using System.Dynamic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcCoreAppTests
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var content = CreateJsonContent(data);
            return httpClient.PostAsync(url, content);
        }

        public static async Task<dynamic> ReadDynamicAsJsonAsync(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(dataAsString);
            return response;
        }

        private static StringContent CreateJsonContent<T>(T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
