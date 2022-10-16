using MangoWeb.Models;
using MangoWeb.Services.IServices;

namespace MangoWeb.Services;

public class CartService : BaseService, ICartService
{
    private readonly IHttpClientFactory _httpClient;
    public CartService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> AddToCartAsync<T>(CartDto cartDto, string accessToken = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartApiBase + "/api/cart/addcart",
            AccessToken = accessToken
        });
    }

    public async Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartApiBase + "/api/cart/applycoupon",
            AccessToken = token
        });
    }

    public async Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartHeader,
            Url = SD.ShoppingCartApiBase + "/api/cart/checkout",
            AccessToken = token
        });
    }

    public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string accessToken = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ShoppingCartApiBase + "/api/cart/getcart/" + userId,
            AccessToken = accessToken
        });
    }

    public async Task<T> RemoveCoupon<T>(string userId, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = userId,
            Url = SD.ShoppingCartApiBase + "/api/cart/removecoupon",
            AccessToken = token
        });
    }

    public async Task<T> RemoveFromCartAsync<T>(int cartId, string accessToken = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartId,
            Url = SD.ShoppingCartApiBase + "/api/cart/removecart",
            AccessToken = accessToken
        });
    }

    public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string accessToken = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            Url = SD.ShoppingCartApiBase + "/api/cart/updatecart",
            AccessToken = accessToken
        });
    }
}