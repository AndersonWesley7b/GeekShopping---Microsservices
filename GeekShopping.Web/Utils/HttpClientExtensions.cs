using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue ContentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(
            this HttpResponseMessage Response)
        {
            if(!Response.IsSuccessStatusCode)throw new ApplicationException($"Something went wrong calling the API: " +
                                                                            $"{Response.ReasonPhrase}");

            var DataAsString = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(DataAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient HttpClient, string Url, T Data)
        {
            var DataAsString = JsonSerializer.Serialize(Data);
            var Content = new StringContent(DataAsString);
            Content.Headers.ContentType = ContentType;
            return HttpClient.PostAsync(Url, Content);
        }
        
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient HttpClient, string Url, T Data)
        {
            var DataAsString = JsonSerializer.Serialize(Data);
            var Content = new StringContent(DataAsString);
            Content.Headers.ContentType = ContentType;
            return HttpClient.PutAsync(Url, Content);
        }
    }
}
