using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeService.Front.Utils
{
    /// <summary>
    /// The Web API Client 
    /// </summary>
    public class WebApiClient
    {
        #region private properties
        /// <summary>
        /// The web api url
        /// </summary>
        /// Put your own Path 
        private static string WebApiUrl = "http://localhost:55602/api/";
        #endregion


        /// <summary>
        /// The Get Async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="url">The controller action url</param>
        /// <returns>deserialized object</returns>
        public static async Task<TEntity> GetAsync<TEntity>(string url)
        {
            try
            {
                string result = string.Empty;
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(WebApiUrl + url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return default(TEntity);
        }

        /// <summary>
        /// The post async method
        /// </summary>
        /// <typeparam name="TRequest">The specified request type</typeparam>
        /// <typeparam name="TResponse">The specified response type</typeparam>
        /// <param name="url">The controller action url</param>
        /// <param name="data">The request as TRequest</param>
        /// <returns>The deserialized object as TResponse</returns>
        public static async Task<TResponse> PostFormJsonAsync<TRequest, TResponse>(string url, TRequest data = default(TRequest))
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        RequestUri = new Uri(WebApiUrl + url),
                        Method = HttpMethod.Post
                    };

                    if (data != null)
                    {
                        string jsonObject = JsonConvert.SerializeObject(data);
                        request.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    }

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return default(TResponse);
        }
    }
}