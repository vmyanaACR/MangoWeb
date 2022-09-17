using MangoWeb.Models;

namespace MangoWeb.Services.IServices;

public interface IProductService : IBaseService
{
    Task<T> GetAllProductsAsync<T>();
    Task<T> GetproductByIdAsync<T>(int id);
    Task<T> CreateProductAsync<T>(ProductDto productDto);
    Task<T> UpdateProductAsync<T>(ProductDto productDto);
    Task<T> DeleteProductAsync<T>(int id);
}