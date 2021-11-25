using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace huskeApi.Helper
{
    public class ApiCaller
    {
        public static async Task<ApiResponse> Get(string url, string authId = null)
        {
            using (var client = new HttpClient())
            {

                var request = await client.GetAsync(url);
                if (request.IsSuccessStatusCode)
                {
                    return new ApiResponse { Response = await request.Content.ReadAsStringAsync() };
                }
                else
                    return new ApiResponse { ErrorMessage = request.ReasonPhrase };
            }
        }
        public static async Task<ApiResponse> Post(string url, string data)
        {
            HttpClient client = new HttpClient();
            StringContent queryString = new StringContent(data);

            var response = await client.PostAsync(new Uri(url), queryString);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse { Response = responseBody };
            }
            else
                return new ApiResponse { ErrorMessage = response.ReasonPhrase };
        }
        public static async Task<ApiResponse> Delete(string url)
        {
            HttpClient client = new HttpClient();
            //StringContent queryString = new StringContent(data);

            var response = await client.DeleteAsync(new Uri(url));

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse { Response = responseBody };
            }
            else
                return new ApiResponse { ErrorMessage = response.ReasonPhrase };
        }
    }

    public class ApiResponse
    {
        public bool Successful => ErrorMessage == null;
        public string ErrorMessage { get; set; }
        public string Response { get; set; }
    }
}
