using MangoWeb.Models;

namespace MangoWeb.Services.IServices;

public interface IProductService : IBaseService
{
    Task<T> GetAllProductsAsync<T>(string accessToken);
    Task<T> GetproductByIdAsync<T>(int id, string accessToken);
    Task<T> CreateProductAsync<T>(ProductDto productDto, string accessToken);
    Task<T> UpdateProductAsync<T>(ProductDto productDto, string accessToken);
    Task<T> DeleteProductAsync<T>(int id, string accessToken);
}