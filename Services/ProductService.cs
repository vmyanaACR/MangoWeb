using MangoWeb.Models;
using MangoWeb.Services.IServices;

namespace MangoWeb.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IHttpClientFactory _httpClient;
    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = productDto,
            Url = SD.ProductApiBase + "/api/products",
            AccessToken = accessToken
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductApiBase + "/api/products/" + id,
            AccessToken = accessToken
        });
    }

    public async Task<T> GetAllProductsAsync<T>(string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products",
            AccessToken = accessToken
        });
    }

    public async Task<T> GetproductByIdAsync<T>(int id, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products/" + id,
            AccessToken = accessToken
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string accessToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = productDto,
            Url = SD.ProductApiBase + "/api/products",
            AccessToken = accessToken
        });
    }
}