using MangoWeb.Models;

namespace MangoWeb.Services.IServices;

public interface IBaseService : IDisposable
{
    ResponseDto ResponseDto { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}