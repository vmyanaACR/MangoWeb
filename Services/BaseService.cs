using System.Net.Http.Headers;
using System.Text;
using MangoWeb.Models;
using MangoWeb.Services.IServices;
using Newtonsoft.Json;

namespace MangoWeb.Services;

public class BaseService : IBaseService
{
    public ResponseDto ResponseDto { get; set; }
    public IHttpClientFactory _httpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        ResponseDto = new ResponseDto();
        _httpClient = httpClient;
    }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var clinet = _httpClient.CreateClient("MangoApi");
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Accept", "application/json");
            requestMessage.RequestUri = new Uri(apiRequest.Url);
            clinet.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                    Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(apiRequest.AccessToken))
            {
                clinet.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
            }

            HttpResponseMessage response = null;
            switch(apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    requestMessage.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    requestMessage.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    requestMessage.Method = HttpMethod.Delete;
                    break;
                default:
                    requestMessage.Method = HttpMethod.Get;
                    break;
            }
            response = await clinet.SendAsync(requestMessage);
            var apiContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<T>(apiContent);
            return apiResponse;
        }
        catch(Exception ex)
        {
            var response = new ResponseDto
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string> { ex.Message },
                IsSuccess = false
            };
            var res = JsonConvert.SerializeObject(response);
            var apiResponse = JsonConvert.DeserializeObject<T>(res);
            return apiResponse;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}