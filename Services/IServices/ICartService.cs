using MangoWeb.Models;

namespace MangoWeb.Services.IServices;

public interface ICartService
{
    Task<T> GetCartByUserIdAsnyc<T>(string userId, string accessToken = null);
    Task<T> AddToCartAsync<T>(CartDto cartDto, string accessToken = null);
    Task<T> UpdateCartAsync<T>(CartDto cartDto, string accessToken = null);
    Task<T> RemoveFromCartAsync<T>(int cartId, string accessToken = null);
    Task<T> ApplyCoupon<T>(CartDto cartDto, string token = null);
    Task<T> RemoveCoupon<T>(string userId, string token = null);
    Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null);
}